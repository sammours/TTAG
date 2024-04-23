namespace TTAK.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TTAG.Domain.Model;
    using TTAG.Domain.Repository;
    using TTAG.Domain.Service;

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly IUserService service;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UsersController(ILogger<UsersController> logger, IUserService service, IMapper mapper, IUserRepository userRepository)
        {
            // build 123
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<User> AddAsync(User user)
        {
            return await this.service.AddOrUpdateAsync(user).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username, string password)
        {
            return this.Ok(this.service.Login(username, password));
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string id)
        {
            return this.Ok(this.mapper.Map<TTAG.Domain.Model.User, UserViewModel>(await this.userRepository.GetByIdAsync(id)));
        }

        [HttpGet("TestYourToken")]
        [Authorize]
        public IActionResult TestYourToken(string username, string password)
        {
            var identity = this.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var idclaim = claims.Where(x => x.Type == "Id").FirstOrDefault();
            return this.Ok(idclaim.Value);
        }
    }
}
