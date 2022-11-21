using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class Expenses
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public ExpensesAmountType AmountType { get; set; }
        public Expenses(string discription, Double Amount, ExpensesAmountType type)
        {
            this.Description = discription;
            this.Amount = Amount;
            AmountType = type;
        }
    }
}
