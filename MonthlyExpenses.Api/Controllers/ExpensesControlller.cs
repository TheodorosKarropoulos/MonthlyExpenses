using Microsoft.AspNetCore.Mvc;
using MonthlyExpenses.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ExpensesControlller : ControllerBase
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
                var result = await service.GetExpensesAsync();
                var expenses = result.Select(x => new Dto.Expense
                {
                    Amount = x.Amount,
                    CategoryId = x.Category.Id,
                    Month = x.Month,
                    Status = x.Status,
                    Year = x.Year.ToString()
                });

                return expenses.ToList();
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

        [HttpPost]
        [Route("categories")]
        public async Task<ActionResult<int>> PostAsync([FromBody] Dto.Category request)
        {
            try
            {
                await service.CreateCategoryAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("categories")]
        public async Task<ActionResult<List<Dto.Category>>> GetCategoriesAsync()
        {
            try
            {
                var result = await service.GetCategoriesAsync();
                return result.Select(x => new Dto.Category
                {
                    Name = x.Name
                }).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
