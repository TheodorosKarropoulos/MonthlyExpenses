using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Service
{
    public interface IExpenseService
    {
        Task<List<Model.Expense>> GetExpensesAsync();
        Task<List<Model.Category>> GetCategoriesAsync();
        Task CreateExpenseAsync(Dto.Expense request);
        Task CreateCategoryAsync(Dto.Category request);
    }
}
