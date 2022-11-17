using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class KataCalculator
    {

        private Product Product;
        private TaxCalculator taxCalculator;
        private DiscountCalculator discountCalculator;

        public KataCalculator(Product product)
        {
            Product = product;
            taxCalculator = new TaxCalculator();
            discountCalculator = new DiscountCalculator();
        }
        public void ApplyTax(double tax)
        {
            taxCalculator.Tax = tax;
        }
        public void ApplyDiscount(double discount)
        {
            discountCalculator.Discount = discount;
        }
        public void CalculatePrice()
        {
            Product.PriceWithTax = Product.Price + taxCalculator.CalculateTaxAmount(Product);
            Product.DiscountAmount = discountCalculator.CalculateDiscountAmount(Product);
            Product.FinalPrice = Product.PriceWithTax - Product.DiscountAmount;

            Console.WriteLine($"Sample product: {Product.ToString()}\n" +
            $"Tax ={taxCalculator.Tax}%, discount ={discountCalculator.Discount}%" +
            $"Tax amount = ${taxCalculator.CalculateTaxAmount(Product):N2};" +
            $" Discount amount = ${Product.DiscountAmount:N2}\n" +
            $"Price before = ${Product.Price}, price after = ${Product.FinalPrice}");
        }
    }
}
