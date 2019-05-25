namespace MonthlyExpenses.Api.Dto
{
    public class Expense
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public Constants.ExpenseStatus Status { get; set; }
    }
}
