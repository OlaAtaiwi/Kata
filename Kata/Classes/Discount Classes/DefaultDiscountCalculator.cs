
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class DefaultDiscountCalculator : IDiscount
    {
        public double Discount { get; private set; }
        public DefaultDiscountCalculator()
        {
            Discount = 15;
        }
        public DefaultDiscountCalculator(double discount)
        {
            Discount = Validate(discount);
        }
        public double CalculateDiscountAmount(Product product)
        {
            return Math.Round(product.Price*(Validate(Discount/100)), 2);
        }

        private static double Validate(double Number)
        {
            if (Number > 100 || Number < 0)
                throw new ArgumentException("Invalid Discount! Discount must be between 0 and 100");
            return Number;
        }

        public double GetDiscountPercent(Product product)
        {
            return Discount;
        }
    }
}
