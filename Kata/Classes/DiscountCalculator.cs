using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class DiscountCalculator
    {
        public double Discount { get; set; }
        public DiscountCalculator()
        {
            Discount = 15;
        }
        public double CalculateDiscountAmount(Product product)
        {
            return Math.Round(product.Price * (Validate(Discount)), 2);
        }
        
        private static double Validate(double Number)
        {
            if (Number > 100 || Number < 0)
                throw new ArgumentException("Invalid Discount! Discount must be between 0 and 100");
            return Number/100;
        }
    }
}
