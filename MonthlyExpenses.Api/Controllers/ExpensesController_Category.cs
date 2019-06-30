using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Controllers
{
    public partial class ExpensesControlller
    {
        [HttpPost]
        [Route("categories")]
        public async Task<ActionResult<int>> PostCategoryAsync([FromBody] Dto.Category request)
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
                return await service.GetCategoriesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        [Route("categories")]
        public async Task<ActionResult> PatchCategoryAsync(string requestId, [FromBody] Dto.Category request)
        {
            if(!int.TryParse(requestId, out var id))
            {
                return BadRequest("Invalid request");
            }

            try
            {
                await service.PartialUpdateCategoryAsync(id, request);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
