using System;

namespace Kata
{
    public static class Report
    {
        public static void ProductFullReport(this KataCalculator kata)
        {
            Console.WriteLine($"Sample product: {kata.Product.ToString()}\n" +
          $"Tax ={kata.taxCalculator.Tax}%, discount ={kata.discountCalculator.GetDiscountPercent(kata.Product)}%" +
          $"Tax amount = ${kata.taxCalculator.CalculateTaxAmount(kata.Product):N2};" +
          $" Discount amount = ${kata.Product.DiscountAmount:N2}\n" +
          $"Price before = ${kata.Product.Price}, price after = ${kata.Product.FinalPrice}");
        }
        public static void DiscountReport(this KataCalculator kata)
        {

            Console.WriteLine($"Sample product:{kata.Product.ToString()}" +
            $"\nTax = {kata.taxCalculator.Tax}%, universal discount = {kata.discountCalculator.defaultDiscount.Discount}%,"+
            $" UPC - discount = {kata.discountCalculator.UPCDiscount.GetDiscountPercent(kata.Product)} % for UPC ={kata.Product.UPC}" +
            $"\nTax amount ={(kata.Product.TaxAmount):N2}," +
            $" default discount = {kata.discountCalculator.defaultDiscount.CalculateDiscountAmount(kata.Product)}," +
            $"UPC discount = ${kata.discountCalculator.UPCDiscount.CalculateDiscountAmount(kata.Product)}" +
            $"\n Program prints price ${kata.Product.FinalPrice}" +
            $"Program reports total discount amount ${kata.Product.DiscountAmount}");

        }
    }
}
