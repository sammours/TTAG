namespace TTAK.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TTAG.Domain.Model;
    using TTAG.Domain.Repository;

    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtController> logger;
        private readonly IArtistRepository repository;

        public ArtistController(ILogger<ArtController> logger, IArtistRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await Task.FromResult(this.repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<Artist> GetAsync(string id)
        {
            return await this.repository.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<Artist> AddAsync(Artist art)
        {
            return await this.repository.AddOrUpdateAsync(art).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<Artist> UpdateAsync(Artist art)
        {
            return await this.repository.AddOrUpdateAsync(art).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(string id)
        {
            return await this.repository.DeleteAsync(id).ConfigureAwait(false);
        }
    }
}
