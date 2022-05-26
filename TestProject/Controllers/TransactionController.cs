using Microsoft.AspNetCore.Mvc;
using TestProject.Authorization;
using TestProject.IServices;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await Task.Run(() => _transactionService.GetAllData());
            return Ok( new { data = data });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(TransactionModel model)
        {
            var data = await Task.Run(() => _transactionService.Insert(model));
            return Ok(data);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await Task.Run(() => _transactionService.Delete(id));
            return Ok(data);
        }


    }
}
