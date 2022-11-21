using System;

namespace Kata
{
    public static class KataCalculatorReport
    {
        public static void DiscountReport(this KataCalculator kata,Product product)
        {
            DiscountCalculator discountCalculator = new DiscountCalculator();
            Console.WriteLine($"Sample product:{product.ToString()}" +
            $"\nTax = {kata.taxCalculator.Tax}%, universal discount = {discountCalculator.defaultDiscount.Discount}%," +
            $" UPC - discount = {discountCalculator.UPCDiscount.GetDiscountPercent(product)} % for UPC ={product.UPC}" +
            $"\nTax amount ={(product.TaxAmount):N2}," +
            $" default discount = {discountCalculator.defaultDiscount.CalculateDiscountAmount(product)}," +
            $"UPC discount = ${discountCalculator.UPCDiscount.CalculateDiscountAmount(product)}" +
            $"\n Program prints price ${product.FinalPrice}" +
            $"Program reports total discount amount ${product.DiscountAmount}");

        }
    }
}
