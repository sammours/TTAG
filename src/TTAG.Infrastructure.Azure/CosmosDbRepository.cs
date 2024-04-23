namespace TTAG.Infrastructure.Azure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos;
    using TTAG.Common;
    using TTAG.Domain;

    public class CosmosDbRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly CosmosClient client;
        private readonly PartitionKey partitionKey;
        private readonly Database database;
        private readonly Container container;

        public CosmosDbRepository(string partitionKeyPath)
        {
            var database = "TTAG";
            var endpoint = "https://ttag.documents.azure.com:443/";
            var primaryKey = "UlYlxBNJ94eOZ0D8FLc77kKRUVoVnireCFAjrZec9oqqAqDgrqTlr7gdsXuFJ1gZY3HdSzkiAjxFrTBUZuk4ng==";
            this.client = new CosmosClient(endpoint, primaryKey);
            this.partitionKey = new PartitionKey(partitionKeyPath);
            this.database = this.client.CreateDatabaseIfNotExistsAsync(database).Result;
            this.container = this.database.CreateContainerIfNotExistsAsync(typeof(TEntity).Name, $"/{partitionKeyPath}").Result;
        }

        public Container Container => this.container;

        public IEnumerable<TEntity> GetAll()
        {
            var query = this.container.GetItemLinqQueryable<TEntity>(allowSynchronousQueryExecution: true);
            return query;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var sqlQuery = new QueryDefinition($"select * from {typeof(TEntity).Name} c where c.id = @id").WithParameter("@id", id);
            var iterator = this.container.GetItemQueryIterator<TEntity>(sqlQuery);

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync().ConfigureAwait(false);
                foreach (var result in response.Resource)
                {
                    return result;
                }
            }

            return default;
        }

        public async Task<TEntity> AddOrUpdateAsync(TEntity entity)
        {
            var dbEntity = await this.GetByIdAsync(entity.Id).ConfigureAwait(false);
            if (dbEntity == null)
            {
                entity.SetCreatedDate();
            }
            else
            {
                entity.CreatedDate = dbEntity.CreatedDate;
            }

            entity.SetLastUpdatedDate();
            var result = await this.container.UpsertItemAsync(entity).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await this.GetByIdAsync(id).ConfigureAwait(false);
            if (entity != null)
            {
                await this.container.DeleteItemAsync<TEntity>(id, this.partitionKey).ConfigureAwait(false);
                return true;
            }

            return false;
        }
    }
}
