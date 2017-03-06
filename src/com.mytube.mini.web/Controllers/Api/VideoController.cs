using System;
using System.Collections.Generic;
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
        public IActionResult Get()
        {
            try
            {
                var result = _repository.GetAll();

                return Ok(Mapper.Map<IEnumerable<VideoViewModel>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] VideoViewModel video)
        {
            if (ModelState.IsValid)
            {
                var newVideo = Mapper.Map<Video>(video);
                _repository.Add(newVideo);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/videos/{video.Name}", Mapper.Map<VideoViewModel>(newVideo));
                }

            }

            return BadRequest("ERROR!");
        }

    }
}
