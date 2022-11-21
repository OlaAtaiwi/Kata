
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class DefaultDiscountCalculator : IDiscount
    {
        private const int _discountPercent = 15;
        public double Discount { get; private set; }

        public DefaultDiscountCalculator()
        {
            Discount = _discountPercent;
        }

        public DefaultDiscountCalculator(double discount)
        {
            Discount = Validator.ValidatePercent(discount);
        }

        public double CalculateDiscountAmount(Product product)
        {
            return Math.Round(product.Price * (Validator.ValidatePercent(Discount / 100)), 2);
        }

        public double GetDiscountPercent(Product product)
        {
            return Discount;
        }
    }
}
