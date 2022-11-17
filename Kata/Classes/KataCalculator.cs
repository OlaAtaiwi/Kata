using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class KataCalculator
    {

        public Product Product;
       public TaxCalculator taxCalculator;
       public DiscountCalculator discountCalculator;

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
            discountCalculator.defaultDiscount = discount;
        }
        public void CalculatePrice()
        {
            Product.PriceWithTax = Product.Price + taxCalculator.CalculateTaxAmount(Product);
            Product.DiscountAmount = discountCalculator.CalculateDiscountAmount(Product);
            Product.FinalPrice = Product.PriceWithTax - Product.DiscountAmount;
        }
    }
}
