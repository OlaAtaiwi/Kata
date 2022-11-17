using System;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("The Little Prince", 12345, 20.25);
            KataCalculator kata = new KataCalculator(product);
            kata.CalculatePrice();
            kata.ApplyTax(21);
            Console.WriteLine("______________________________________________________________________________");
            kata.ApplyDiscount(20);
            kata.CalculatePrice();
            Console.WriteLine("______________________________________________________________________________");
        }
    }
}
