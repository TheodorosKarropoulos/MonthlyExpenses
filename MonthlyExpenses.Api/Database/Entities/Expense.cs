using System;
using System.Collections.Generic;
using System.Text;

namespace MonthlyExpenses.Api.Database
{
    public class Expense
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public byte Status { get; set; }
        public int CategoryId { get; set; }
    }
}
