using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class AfterTaxDefaultDiscounter : IAfterTaxDiscount
    {
        private const int _discountPercent = 15;
        public double Discount { get; set; }
        public AfterTaxDefaultDiscounter()
        {
            Discount = _discountPercent;
        }

        public AfterTaxDefaultDiscounter(double discount)
        {
            Discount = Validator.ValidatePercent(discount);
        }

        public double CalculateDiscountsAfter(Product product, double Price)
        {
            return Math.Round(Price * (Validator.ValidatePercent(Discount) / 100), 2);
        }
    }
}
