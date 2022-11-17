using System;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("The Little Prince", 12, 20.25);
            KataCalculator kata = new KataCalculator(product);
            Console.WriteLine("Case#1");
            kata.CalculatePrice();
            kata.DiscountReport();
            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine("Case#2");
            kata = new KataCalculator(new Product("The Little Prince", 1234, 20.25));
            kata.ApplyDiscount(0);
            kata.CalculatePrice();
            kata.DiscountReport();
            Console.WriteLine("______________________________________________________________________________");
        }
    }
}
