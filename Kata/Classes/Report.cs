using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public static class Report
    {
        public static void ProductFullReport(this KataCalculator kata)
        {
            Console.WriteLine($"Sample product: {kata.Product.ToString()}\n" +
          $"Tax ={kata.taxCalculator.Tax}%, discount ={kata.discountCalculator.Discount}%" +
          $"Tax amount = ${kata.taxCalculator.CalculateTaxAmount(kata.Product):N2};" +
          $" Discount amount = ${kata.Product.DiscountAmount:N2}\n" +
          $"Price before = ${kata.Product.Price}, price after = ${kata.Product.FinalPrice}");
        }
        public static void DiscountReport(this KataCalculator kata)
        {

            Console.WriteLine($"Sample product: {kata.Product.ToString()}\n");
            Console.WriteLine($"Program prints Final price = ${kata.Product.FinalPrice:N2}\n");
            Console.Write($"Tax ={kata.taxCalculator.Tax}%,  ");
            if (kata.discountCalculator.Discount == 0)
            {
                Console.WriteLine("no discount");
                Console.WriteLine("Program doesn’t show any discounted amount.");
            }
            else
            {
                Console.WriteLine($"discount ={kata.discountCalculator.Discount}%\n");
                Console.WriteLine( $"Program displays  ${ kata.Product.DiscountAmount:N2} amount which was deduced\n");
            }
        }
    }
}
