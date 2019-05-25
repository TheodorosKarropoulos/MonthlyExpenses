using Microsoft.EntityFrameworkCore;
using MonthlyExpenses.Api.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Repository
{
    public class ExpensesRepository
    {
        private readonly ExpenseDbContext context;

        public ExpensesRepository(ExpenseDbContext context)
        {
            this.context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Database.Expense>> GetExpensesAsync()
        {
            var expenses = context.Set<Database.Expense>();

            if (!expenses.Any())
            {
                return new List<Expense>();
            }

            return await expenses.ToListAsync();
        }

        public async Task<List<Database.Category>> GetCategoriesAsync()
        {
            var result = context.Set<Database.Category>();

            if(!result.Any())
            {
                return new List<Category>();
            }

            return await result.ToListAsync();
        }

        public async Task<Model.Category> GetCategoryByIdAsync(int id)
        {
            var result = await context.Set<Database.Category>()
                .FindAsync(id);

            return new Model.Category
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            await context.AddAsync(entity);
        }

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
