using System;
using System.Collections.Generic;
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
        public IEnumerable<User> GetAll(CancellationToken token)
        {
            return _repository.GetAll(token);
        }

        [HttpGet("{id:int}")]
        public User GetById(CancellationToken token, int id)
        {
            return _repository.GetById(token, id);
        }

        [HttpPost("")]
        public User Add(CancellationToken token, [FromBody] User user)
        {
            _repository.Add(token, user);
            _repository.Save(token);
            return user;
        }

        [HttpPost("login")]
        public IActionResult Login(CancellationToken token, [FromBody]User user)
        {
            if (user == null)
                return NotFound("User doesn't exist");

            var dbUser = _repository.GetByLogin(token, user.Login);
            if (PasswordHash.PasswordHash.ValidatePassowrd(user.Password, dbUser.Password))
            {
                dbUser.Password = string.Empty;
                return Ok(dbUser);
            }

            return BadRequest();
        }
    }
}
