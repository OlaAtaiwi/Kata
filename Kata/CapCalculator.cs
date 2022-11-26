using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class CapCalculator
    {
        public double Amount { get; set; }
        public AmountType CapAmountType { get; set; }
        public CapCalculator(double amount, AmountType type)
        {
            Amount = amount;
            CapAmountType = type;
        }
        public double CalculateCap(Product product)
        {
            if (CapAmountType == AmountType.Percent)
                return Math.Round(product.Price * (Validator.ValidatePercent(Amount) / 100), 2);
            else
                return Amount;
        }
    }
}
