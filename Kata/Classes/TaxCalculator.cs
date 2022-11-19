using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
   public  class TaxCalculator
    {
        const int taxPercent = 20;
        public double Tax { get; set; }
        public TaxCalculator()
        {
            Tax = taxPercent;
        }

        public TaxCalculator(double tax)
        {
            Tax = Validator.ValidatePercent(tax);
        }

        public double CalculateTaxAmount(Product product)
        {
            return Math.Round(product.Price*(Validator.ValidatePercent(Tax)/100), 2);
        }
    }
}
