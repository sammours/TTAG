namespace TTAK.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TTAG.Domain.Model;
    using TTAG.Domain.Profile.Helpers;
    using TTAG.Domain.Repository;

    [ApiController]
    [Route("[controller]")]
    public class ArtController : ControllerBase
    {
        private readonly ILogger<ArtController> logger;
        private readonly IArtRepository repository;
        private readonly IProfileHelper profileHelper;

        public ArtController(ILogger<ArtController> logger, IArtRepository repository, IProfileHelper profileHelper)
        {
            this.logger = logger;
            this.repository = repository;
            this.profileHelper = profileHelper;

            // try build
        }

        [HttpGet]
        public async Task<IEnumerable<Art>> GetAllAsync()
        {
            return await Task.FromResult(this.repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<Art> GetAsync(string id)
        {
            if (!this.profileHelper.IsAdmin())
            {
                throw new UnauthorizedAccessException($"User {this.profileHelper.GetEmail()} is not authorized");
            }

            // var profile = this.profileHelper.GetCurrentProfile();
            return await this.repository.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<Art> AddAsync(Art art)
        {
            return await this.repository.AddOrUpdateAsync(art).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<Art> UpdateAsync(Art art)
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
