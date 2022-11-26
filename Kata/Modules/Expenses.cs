using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class Expenses
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public AmountType AmountType { get; set; }
        public Expenses(string discription, Double Amount, AmountType type)
        {
            this.Description = discription;
            this.Amount = Amount;
            AmountType = type;
        }
    }
}
