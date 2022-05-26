using Microsoft.AspNetCore.Mvc;
using TestProject.Authorization;
using TestProject.IServices;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly ITranslationService _translationService;

        public UserController(IUserService userService, IMailService mailService, ITranslationService translationService)
        {
            _userService = userService;
            _mailService = mailService;
            _translationService = translationService;

        }

        [Authorize]
        [Route("GetDif")]
        [HttpGet]
        public async Task<IActionResult> GetDif()
        {
            var data = await Task.Run(() => _userService.TestService());
            return Ok(data);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await Task.Run(() => _userService.GetAllData());
            return Ok( new { data = data });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(UserModel model)
        {
            var data = await Task.Run(() => _userService.Insert(model));
            return Ok(data);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await Task.Run(()=> _userService.Delete(id));
            return Ok(data);
        }

    

        [Route("/SendMail")]
        [HttpGet]
        public async Task<IActionResult> SendMail(string to, string subject, string body)
        {
            var data = await Task.Run(() => _mailService.SendEmail(to, subject, body));
            return Ok(data);
        }


        [Route("/GetCurrentUser")]
        [HttpGet]
        public ActionResult GetCurrentUser()
        {
            return Ok(Utils.GetCurrentToken());
        }

        [Authorize]
        [Route("/Translate")]
        [HttpGet]
        public async Task<IActionResult>  Translate(string input)
        {
            var data = await Task.Run(() => _translationService.TransalateMe(input));
            return Ok(data);
        }

    }
}
