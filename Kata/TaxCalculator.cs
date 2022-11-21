using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
   public  class TaxCalculator
    {
        private const int _taxPercent = 20;
        public double Tax { get; set; }
        public TaxCalculator()
        {
            Tax = _taxPercent;
        }

        public double CalculateTaxAmount(double Price)
        {
            return Math.Round(Price*(Validator.ValidatePercent(Tax)/100), 2);
        }

    }
}
