using com.mytube.mini.core.Contracts;
using com.mytube.mini.web.Services;
using com.mytube.mini.web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace com.mytube.mini.web.Controllers.Web
{
    public class AppController : Controller
    {
        private ILogger<AppController> _logger;
        private IConfigurationRoot _config;
        private IMailService _mailService;

        public AppController(IMailService mailService,
            IConfigurationRoot config,
            ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                //TODO GET ALL
                //var videos = _repository.GetAllVideos();
                //var users = _repository.GetAllUsers();
                //var ratings = _repository.GetAllRatings();

               return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed!!{ex.Message}");
                return Redirect("/error");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(SigninViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From Mytube", model.Message);

                ModelState.Clear();

                ViewBag.UserMessage = "Message Sent";
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(SigninViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From Mytube", model.Message);

                ModelState.Clear();
            }

            return View();
        }
    }
}
