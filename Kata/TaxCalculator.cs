using System;

namespace Kata
{
    public class TaxCalculator
    {
        private const int _taxPercent = 20;
        public double Tax { get; set; }
        public TaxCalculator()
        {
            Tax = _taxPercent;
        }

        public TaxCalculator(double tax)
        {
            Tax = Validator.ValidatePercent(tax);
        }

        public double CalculateTaxAmount(Product product)
        {
            return Math.Round(product.Price * (Validator.ValidatePercent(Tax) / 100), 2);
        }
    }
}
