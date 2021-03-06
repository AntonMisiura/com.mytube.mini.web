﻿//using System.Threading;
//using com.mytube.mini.core.Contracts;
//using com.mytube.mini.web.Services;
//using com.mytube.mini.web.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Authorization;

//namespace com.mytube.mini.web.Controllers.Web
//{
//    public class AppController : Controller
//    {
//        private CancellationToken _token;
//        private IConfigurationRoot _config;
//        private IMailService _mailService;
//        private IUserRepository _userRepository;

//        public AppController(IMailService mailService,
//            IConfigurationRoot config,
//            IUserRepository userRepository )
//        {
//            _mailService = mailService;
//            _config = config;
//            _userRepository = userRepository;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        [Authorize]
//        public IActionResult Users()
//        {
//            var users = _userRepository.GetAll(_token);
//            return View(users);
//        }

//        public IActionResult Login()
//        {
//            return View();
//        }

//        public IActionResult Signin()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Signin(SigninViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From Mytube", model.Message);

//                ModelState.Clear();

//                ViewBag.UserMessage = "Message Sent";
//            }

//            return View();
//        }

//        //[HttpPost]
//        //public IActionResult Login(SigninViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From Mytube", model.Message);

//        //        ModelState.Clear();
//        //    }

//        //    return View();
//        //}
//    }
//}
