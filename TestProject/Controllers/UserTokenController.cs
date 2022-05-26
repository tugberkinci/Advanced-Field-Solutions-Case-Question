using Microsoft.AspNetCore.Mvc;
using TestProject.Authorization;
using TestProject.IServices;

namespace TestProject.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        private readonly IUserTokenService _userTokenService;

        public UserTokenController(IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await Task.Run(() => _userTokenService.GetAllData());
            return Ok(data);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(int userId)
        {
            var data = await Task.Run(() => _userTokenService.Insert(userId));
            return Ok(data);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await Task.Run(() => _userTokenService.Delete(id));
            return Ok(data);
        } 
    }
}
