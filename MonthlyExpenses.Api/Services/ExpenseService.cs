using MonthlyExpenses.Api.Model;
using MonthlyExpenses.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpensesRepository repository;

        public ExpenseService(ExpensesRepository repository)
        {
            this.repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task CreateCategoryAsync(Dto.Category request)
        {
            var category = new Database.Category
            {
                Name = request.Name
            };

            try
            {
                await repository.CreateAsync(category);
                await repository.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task CreateExpenseAsync(Dto.Expense request)
        {
            if (!int.TryParse(request.Year, out var year))
            {
                throw new ArgumentException("Invalid year value");
            }

            var expense = new Database.Expense
            {
                Amount = request.Amount,
                Month = request.Month,
                Status = (byte)request.Status,
                Year = year,
                CategoryId = request.CategoryId
            };

            try
            {
                await repository.CreateAsync(expense);
                await repository.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var results = await repository.GetCategoriesAsync();
                return results.Select(x => new Category
                {
                    Name = x.Name
                }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Model.Expense>> GetExpensesAsync()
        {
            try
            {
                var expenses = new List<Model.Expense>();
                var results = await repository.GetExpensesAsync();
                foreach (var result in results)
                {
                    var expense = new Model.Expense
                    {
                        Amount = result.Amount,
                        Month = result.Month,
                        Status = (Constants.ExpenseStatus)result.Status,
                        Year = result.Year
                    };
                    expense.Category = await repository.GetCategoryByIdAsync(result.CategoryId);
                    expenses.Add(expense);
                }
                return expenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
