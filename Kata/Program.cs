using System;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("The Little Prince", 12345, 20.25);
            Console.WriteLine(product.ToString());
            TaxCalculator.PriceWithTax(product, 20);
            TaxCalculator.PriceWithTax(product, 21);

        }
    }
}
