using System;
using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.mytube.mini.web.Controllers.Api
{
    [Route("api/rating")]
    public class RatingController : ApiController
    {
        protected override string Tag => nameof(RatingController);

        private IRepository<Rating> _repository;


        public RatingController(
            IRepository<Rating> repository,
            ILogger<ApiController> logger)
            : base(logger)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return await HandleAjaxCall(() => _repository.GetAll(token));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(CancellationToken token, int id)
        {
            return await HandleAjaxCall(() => _repository.GetById(token, id));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddRating(CancellationToken token, [FromBody] Rating rating)
        {
            return await HandleAjaxCall(async () =>
            {
                await _repository.Add(token, rating);
                await _repository.Save(token);
                return rating;
            });
        }

    }
}
