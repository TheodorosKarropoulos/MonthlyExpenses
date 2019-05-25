using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonthlyExpenses.Api.Database
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("Expense_Category")
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
