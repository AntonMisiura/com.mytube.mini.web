using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using com.mytube.mini.web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace com.mytube.mini.web.Controllers.Api
{
    [Route("api/videos")]
    public class VideoController : Controller
    {
        private IRepository<Video> _repository;

        public VideoController(IRepository<Video> repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get(CancellationToken token)
        {
            try
            {
                var result = _repository.GetAll(token);

                return Ok(Mapper.Map<IEnumerable<VideoViewModel>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(CancellationToken token, int id)
        {
            return Ok(_repository.GetById(token, id));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(CancellationToken token, [FromBody] VideoViewModel video)
        {
            if (ModelState.IsValid)
            {
                var newVideo = Mapper.Map<Video>(video);
                _repository.Add(token, newVideo);

                if (await _repository.Save(token))
                {
                    return Created($"api/videos/{video.Name}", Mapper.Map<VideoViewModel>(newVideo));
                }

            }

            return BadRequest("ERROR!");
        }

    }
}
