using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Service
{
    public interface IExpenseService
    {
        Task<List<Dto.Expense>> GetExpensesAsync();
        Task<List<Dto.Category>> GetCategoriesAsync();
        Task CreateExpenseAsync(Dto.Expense request);
        Task CreateCategoryAsync(Dto.Category request);
        Task PartialUpdateCategoryAsync(int id, Dto.Category request);
    }
}
