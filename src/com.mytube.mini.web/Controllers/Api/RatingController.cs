using System.Threading;
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
        public IActionResult Get(CancellationToken token)
        {
            return Ok(_repository.GetAll(token));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(CancellationToken token, [FromBody] Rating rating)
        {
            if (ModelState.IsValid)
            {
                var newRating = Mapper.Map<Rating>(rating);
                await _repository.Add(token, newRating);

                if (await _repository.Save(token))
                {
                    return Created($"api/ratings/{rating.Mark}", Mapper.Map<RatingViewModel>(newRating));
                }

            }

            return BadRequest("ERROR!");
        }
    }
}
