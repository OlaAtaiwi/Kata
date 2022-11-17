using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
   public  class TaxCalculator
    {
        public double Tax { get; set; }
        public TaxCalculator()
        {
            Tax = 20;
        }
        public double CalculateTaxAmount(Product product)
        {
            return Math.Round(product.Price*(Validate(Tax)), 2);
        }
        private static double Validate(double Number)
        {
            if (Number > 100 || Number < 0)
                throw new ArgumentException("Invalid tax! Tax must be between 0 and 100");
            return Number/100;
        }
    }
}
