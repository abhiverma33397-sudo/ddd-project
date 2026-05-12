using Application.Users.TransactionDtos.Transaction_A;
using Application.Users.Transactions.TransactionDtos;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAll(int userId)
        {
            var result = await _application.GetAll(userId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Dashboard-Summery")]
        public async Task<IActionResult> GetUserDashboard(
        CancellationToken cancellationToken)
        {
            var userId = User.Claims
                .FirstOrDefault(c => c.Type == "UserId")?.Value;

            var result = await _application
                .GetUserDashboard(userId, cancellationToken);

            return Ok(result);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateTransactionDto dto)
        {
            var userid = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
           
            var result = await _application.Create(dto, userid);
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


