using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace com.mytube.mini.web.Controllers.Api
{
    public abstract class ApiController : Controller
    {
        protected ILogger<ApiController> Logger { get; private set; }
        protected abstract string Tag { get; }

        protected ApiController(ILogger<ApiController> logger)
        {
            Logger = logger;
        }

        protected async Task<IActionResult> HandleAjaxCall<T>(Func<Task<T>> action)
        {
            try
            {
                var result = await action();
                if (result == null)
                    return NotFound("Object doesn't found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(Tag, ex);

                return StatusCode((int) HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
