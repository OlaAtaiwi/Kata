using System;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("The Little Prince", 1212, 20.25);
            KataCalculator kata = new KataCalculator(product);
            Console.WriteLine("Case#1");
            kata.CalculatePrice();
            kata.DiscountReport();
            Console.WriteLine("______________________________________________________________________________");

        }
    }
}
