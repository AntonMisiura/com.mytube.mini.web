using System;
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
            return await HandleAjaxCall(() => _repository.GetById(token, id));
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(CancellationToken token, [FromBody] User user)
        {
            return await HandleAjaxCall(async () =>
            {
                await _repository.Add(token, user);
                await _repository.Save(token);
                return user;
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CancellationToken token, [FromBody]User user)
        {
            if (user == null)
                return NotFound("User doesn't exist");

            var dbUser = await _repository.GetByLogin(token, user.Login);
            if (PasswordHash.PasswordHash.ValidatePassowrd(user.Password, dbUser.Password))
            {
                dbUser.Password = string.Empty;
                return Ok(dbUser);
            }

            return BadRequest();
        }
    }
}
