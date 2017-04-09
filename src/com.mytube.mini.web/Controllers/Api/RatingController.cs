using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.mytube.mini.web.Controllers.Api
{
    [Route("api/ratings")]
    public class RatingController : ApiController
    {
        protected override string Tag => nameof(RatingController);

        private IRatingRepository _repository;


        //TODO: HTTP module as a base for logging and exception handling
        // Add stopwatch
        // Remove multiple SQL calls
        // Move to React
        //autologin
        //remove async task
        //talk about httpmodule, that it must do all that doing apicontroller now
        //remove from constructor repository and logger
        //private field _repository move to api controller, or create other to do this
        public RatingController(
            IRatingRepository repository,
            ILogger<ApiController> logger)
            : base(logger)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IEnumerable<Rating> GetAll(CancellationToken token)
        {
            return _repository.GetAll(token);
        }

        [HttpGet("{id:int}")]
        public Rating GetById(CancellationToken token, int id)
        {
            return _repository.GetById(token, id);
        }

        [HttpGet("videos/{id:int}")]
        public IEnumerable<Rating> GetAll(CancellationToken token, int id)
        {
            return _repository.GetByVideoId(token, id);
        }

        [HttpPost("")]
        public Rating AddRating(CancellationToken token, [FromBody] Rating rating)
        {
            _repository.Add(token, rating);
            _repository.Save(token);
            return rating;
        }

    }
}
