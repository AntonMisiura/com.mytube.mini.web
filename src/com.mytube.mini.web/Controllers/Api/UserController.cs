using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.mytube.mini.web.Controllers.Api
{
    [Route("api/users")]
    public class UserController : ApiController
    {
        protected override string Tag => nameof(UserController);

        private IUserRepository _repository;


        public UserController(
            ILogger<ApiController> logger,
            IUserRepository repository)
            : base(logger)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return await HandleAjaxCall(()=>_repository.GetAll(token));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(CancellationToken token, int id)
        {
            return await HandleAjaxCall(() => _repository.GetById(id));
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            return await HandleAjaxCall(async() =>
            {
                await _repository.Add(user);
                await _repository.Save();
                return user;
            });

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]User user)
        {
            if (user == null)
            {
                return NotFound("User doesn't exist");
            }

            var dbUser = _repository.GetByLogin(user.Login);
            if (user.Password == dbUser.Password)
            {
                return Ok("Logged in");
            }

            return View();
        }
    }
}
