using System;

namespace Kata
{
    public class TaxCalculator
    {
        public static void PriceWithTax(Product product, double tax)
        {
            product.PriceAfterTax = Math.Round(product.Price * (1 + ValidateTax(tax)), 2);
            ReportPrinter.PrintPrices(product, tax);
        }
        private static double ValidateTax(double tax)
        {
            if (tax > 100 || tax < 0)
                throw new ArgumentException("Invalid tax! Tax must be between 0 and 100");
            return tax / 100;
        }


    }
}
