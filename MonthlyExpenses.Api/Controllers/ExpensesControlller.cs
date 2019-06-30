using Microsoft.AspNetCore.Mvc;
using MonthlyExpenses.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public partial class ExpensesControlller : ControllerBase
    {
        private readonly IExpenseService service;

        public ExpensesControlller(IExpenseService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("expenses")]
        public async Task<ActionResult<List<Dto.Expense>>> GetAllAsync()
        {
            try
            {
                return await service.GetExpensesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("expenses")]
        public async Task<ActionResult> PostAsync([FromBody] Dto.Expense request)
        {
            try
            {
                await service.CreateExpenseAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
