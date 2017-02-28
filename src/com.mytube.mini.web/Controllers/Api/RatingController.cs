using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using com.mytube.mini.impl.EF.Repo;
using Microsoft.AspNetCore.Mvc;

namespace com.mytube.mini.web.Controllers.Api
{
    [Route("api/rating")]
    public class RatingController : Controller
    {
        private IRepository<Rating> _repository;

        public RatingController(IRepository<Rating> repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] Rating rating)
        {
            return Ok(true);
        }
    }
}
