using System.Threading.Tasks;
using AutoMapper;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using com.mytube.mini.web.ViewModels;
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
        public async Task<IActionResult> Post([FromBody] Rating rating)
        {
            if (ModelState.IsValid)
            {
                var newRating = Mapper.Map<Rating>(rating);
                _repository.Add(newRating);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/ratings/{rating.Mark}", Mapper.Map<RatingViewModel>(newRating));
                }

            }

            return BadRequest("ERROR!");
        }
    }
}
