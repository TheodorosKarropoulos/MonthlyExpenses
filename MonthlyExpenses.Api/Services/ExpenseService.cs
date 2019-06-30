using AutoMapper;
using MonthlyExpenses.Api.Dto;
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
        private readonly IMapper mapper;

        public ExpenseService(ExpensesRepository repository,
            IMapper mapper)
        {
            this.repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task CreateCategoryAsync(Dto.Category request)
        {
            var category = mapper.Map<Database.Category>(request);
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
                Status = request.Status,
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

        public async Task<List<Dto.Category>> GetCategoriesAsync()
        {
            try
            {
                var results = await repository.GetCategoriesAsync();
                return mapper.Map<List<Dto.Category>>(results);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Dto.Expense>> GetExpensesAsync()
        {
            try
            {
                var expenses = new List<Model.Expense>();
                var results = await repository.GetExpensesAsync();
                return mapper.Map<List<Dto.Expense>>(results);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task PartialUpdateCategoryAsync(int id, Dto.Category category)
        {
            var result = await repository.GetCategoryByIdAsync(id);
            if (result != null)
            {
                await repository.UpdateAsync(result);
                try
                {
                    await repository.CommitAsync();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
