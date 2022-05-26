
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

using TestProject.DbContexts;
using TestProject.IServices;
using TestProject.Models;
using TestProject.Services;

namespace LoginRegistrationInMVCWithDatabase.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserTokenService _userTokenService;

        public AccountController(IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;
        }

        public ActionResult Index()
        {
            
            if (!Utils.IsLogin())
                return View("Views/Home/Index.cshtml");

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Users()
        {
            if (!Utils.IsLogin())
                return View("Views/Home/Index.cshtml");

            return View(Utils.GetCurrentToken());
        }
        
        
        public ActionResult Translator(TranslateModel model)
        {
            if (!Utils.IsLogin())
                return View("Views/Home/Index.cshtml");

            model.Token = Utils.GetCurrentToken().Token;
            model.Secret = Utils.GetCurrentToken().Secret;
       

            
            return View(model);
            
        }

        public ActionResult Transactions()
        {
            if(!Utils.IsLogin())
                return View("Views/Home/Index.cshtml");

            return View(Utils.GetCurrentToken());

        }

       
        [HttpPost]
        public  ActionResult Login(UserTokenModel model)
        {
            if (ModelState.IsValid)
            {
                if(!String.IsNullOrEmpty(model.Token))
                    model.Token = model.Token.Replace(" ", "");

                if (!String.IsNullOrEmpty(model.Secret))
                    model.Secret = model.Secret.Replace(" ", "");
                var isValidUser = _userTokenService.Validate(model.Token, model.Secret);


                if (isValidUser == null)
                {
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");

                    return View("Views/Home/Index.cshtml");
                }

                Utils.SetCurrentUser(isValidUser);

                return View("Index", isValidUser);

            }
            else
            {
                return View(model);
            }


        }

        public ActionResult Translate(TransactionModel model)
        {

            return View();
        }

       

   
      
    }
}