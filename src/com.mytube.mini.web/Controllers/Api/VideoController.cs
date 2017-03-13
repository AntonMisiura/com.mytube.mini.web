using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.mytube.mini.web.Controllers.Api
{
    [Route("api/videos")]
    public class VideoController : ApiController
    {
        protected override string Tag => nameof(UserController);

        private IRepository<Video> _repository;

        public VideoController(
            IRepository<Video> repository,
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
        public async Task<IActionResult> Post(CancellationToken token, [FromBody] Video video)
        {
            return await HandleAjaxCall(async () =>
            {
                await _repository.Add(token, video);
                await _repository.Save(token);
                return video;
            });

        }
    }
}
