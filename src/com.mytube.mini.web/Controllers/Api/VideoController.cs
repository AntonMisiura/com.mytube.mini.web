using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace com.mytube.mini.web.Controllers.Api
{
    [Route("api/videos")]
    public class VideoController : ApiController
    {
        protected override string Tag => nameof(UserController);

        private IVideoRepository _repository;
        private IConfigurationRoot _config;

        public VideoController(
            IVideoRepository repository,
            IConfigurationRoot config,
            ILogger<ApiController> logger)
            : base(logger)
        {
            _repository = repository;
            _config = config;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return await HandleAjaxCall(() => _repository.GetAll(token));
        }

        [HttpGet("users/{id:int}")]
        public async Task<IActionResult> GetAll(CancellationToken token, int id)
        {
            return await HandleAjaxCall(() => _repository.GetByUser(token, id));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(CancellationToken token, int id)
        {
            return await HandleAjaxCall(() => _repository.GetById(token, id));
        }

        [HttpGet("content/{id:int}")]
        public async Task<FileStreamResult> GetFile(CancellationToken token, int id)
        {
            try
            {
                var video = await _repository.GetById(token, id);
                var stream = new FileStream(video.Path, FileMode.Open);
                return new FileStreamResult(stream, "video/mp4")
                {
                    FileDownloadName = $"video{video.Id}.mp4"
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(Tag, ex);

                throw new Exception();
            }
        }

        [HttpPost, Route("upload")]
        public async Task<IActionResult> AddFile(CancellationToken token)
        {
            try
            {

                // Read from data
                var formData = await Request.ReadFormAsync(token);


                // Save video metadata
                StringValues values;
                formData.TryGetValue("metadata", out values);
                var video = JsonConvert.DeserializeObject<Video>(values[0]);

                // Save splash screen
                video.ScreenPath = string.Empty;

                // Save video to file system
                var path = "./microtube/videos/"; //TODO: Move to config.json
                Directory.CreateDirectory(path);

                foreach (var file in formData.Files)
                {
                    if (file.Length > 0)
                    {
                        var uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        video.Path = Path.Combine(path, uniqueName);
                        using (var fileStream = new FileStream(video.Path, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream, token);
                        }
                        break;
                    }
                }

                // Save video in DB
                await _repository.Add(token, video);
                await _repository.Save(token);

                return Ok(video);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
