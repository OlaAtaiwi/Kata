using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class BeforeTaxDefaultDiscounter : IBeforeTaxDiscount
    {
        private const int _discountPercent = 15;
        public double Discount { get; set; }
        public BeforeTaxDefaultDiscounter()
        {
            Discount = _discountPercent;
        }

        public BeforeTaxDefaultDiscounter(double discount)
        {
            Discount = Validator.ValidatePercent(discount);
        }

        public double CalculateDiscountsBefore(Product product)
        {
            return Math.Round(product.Price * (Validator.ValidatePercent(Discount) / 100), 2);
        }
    }
}
