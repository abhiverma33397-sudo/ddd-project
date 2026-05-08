using Application.Users.TransactionDtos.Transaction_A;
using Application.Users.Transactions.TransactionDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAp_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionApplication _application;

        public TransactionController(ITransactionApplication application)
        {
            _application = application;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _application.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateTransactionDto dto)
        {
            var result = await _application.Create(dto);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _application.GetById(id);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id, CreateUpdateTransactionDto dto)
        {

            try
            {
                await _application.Update(id, dto);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _application.Delete(id);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}


