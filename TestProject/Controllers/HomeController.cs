using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestProject.DbContexts;
using TestProject.Entities;
using TestProject.IServices;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly IUserTokenService _userTokenService;


        public HomeController(ILogger<HomeController> logger,IUserService userService,IMailService mailService,IUserTokenService userTokenService)
        {
            _logger = logger;
            _userService = userService;
            _mailService = mailService;
            _userTokenService = userTokenService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Register(UserModel model)
        {
            if (!Utils.IsValidEmail(model.UserMail))
            {
                ModelState.AddModelError("Failure", "Invalid mail adress");
                return View("Views/Home/Register.cshtml");
            }

            User data = _userService.GetByMail(model.UserMail);

            if(data != null)
            {
                var token = _userTokenService.GetByUserId(data.Id);
                if (token == null)
                    token= _userTokenService.Insert(data.Id);

                _mailService.SendEmail(model.UserMail, "Token Request", $"Token : {token.Token} Secret: {token.Secret}");
                return View("Views/Home/Register.cshtml");
            }

            data = _userService.Insert(model);

            if(data.Id != 0 || data.Id != null )
            {
                var token = _userTokenService.GetByUserId(data.Id);
                if (token == null)
                    token = _userTokenService.Insert(data.Id);

                _mailService.SendEmail(model.UserMail, "Token Request", $"Token : {token.Token} Secret: {token.Secret}");
                return View("Views/Home/Register.cshtml");

            }


            ModelState.AddModelError("Failure", "An error occured");
            return View("Views/Home/Register.cshtml");



        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}