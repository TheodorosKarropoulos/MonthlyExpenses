namespace MonthlyExpenses.Api.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public Constants.ExpenseStatus Status { get; set; }
        public Category Category { get; set; }
    }
}
