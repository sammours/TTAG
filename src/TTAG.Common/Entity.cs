namespace TTAG.Common
{
    using System;
    using Newtonsoft.Json;

    public class Entity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public void SetCreatedDate()
        {
            this.CreatedDate = DateTime.UtcNow;
        }

        public void SetLastUpdatedDate()
        {
            this.LastUpdatedDate = DateTime.UtcNow;
        }
    }
}
