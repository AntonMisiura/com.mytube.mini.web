using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using com.mytube.mini.impl.EF.Repo;
using Microsoft.AspNetCore.Mvc;

namespace com.mytube.mini.web.Controllers.Api
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] User user)
        {
            return Ok(true);
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

            return Ok("Bye!");
        }
    }
}
