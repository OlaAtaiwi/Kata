using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class ReportPrinter
    {
        public static void PrintPrices(Product product, double tax)
        {
            Console.WriteLine($"Product price reported as ${product.Price} before tax and ${product.PriceAfterTax:N2} after {tax}% tax.");
        }
    }
}
