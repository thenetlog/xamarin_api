using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Models
{
    public class Expense
    {
        public string ExpenseId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Particular { get; set; }
        public string Amount { get; set; }
    }
}
