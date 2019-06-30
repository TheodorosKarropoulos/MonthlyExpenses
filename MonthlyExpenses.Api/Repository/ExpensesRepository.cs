using AutoMapper;
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
        private readonly IMapper mapper;

        public ExpensesRepository(ExpenseDbContext context,
            IMapper mapper)
        {
            this.context = context
                ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Model.Expense>> GetExpensesAsync()
        {
            var result = await context
                .Set<Database.Expense>()
                .ToListAsync();

            if (!result.Any())
            {
                return new List<Model.Expense>();
            }

            try
            {
                return mapper.Map<List<Database.Expense>, List<Model.Expense>>(result);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Model.Category>> GetCategoriesAsync()
        {
            var result = await context.Set<Database.Category>()
                .ToListAsync();

            if (!result.Any())
            {
                return new List<Model.Category>();
            }

            try
            {
                return mapper.Map<List<Model.Category>>(result);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Model.Category> GetCategoryByIdAsync(int id)
        {
            var result = await context.Set<Database.Category>()
                .FindAsync(id);

            return mapper.Map<Model.Category>(result);
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            await context.AddAsync(entity);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            var existing = await context.Set<T>().FindAsync(entity);
            mapper.Map(entity, existing);
        }

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
