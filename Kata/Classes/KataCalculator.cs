using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class KataCalculator
    {

       public Product Product { get; private set; }
       public TaxCalculator taxCalculator { get; private set; }
       public DiscountCalculator discountCalculator { get; private set; }

        public KataCalculator(Product product)
        {
            Product = product;
            taxCalculator = new TaxCalculator();
            discountCalculator = new DiscountCalculator();
        } 

        public void CalculatePrice()
        {
            Product.TaxAmount =taxCalculator.CalculateTaxAmount(Product);
            Product.DiscountAmount = discountCalculator.CalculateDiscountAmount(Product);
            Product.FinalPrice = Product.Price + Product.TaxAmount - Product.DiscountAmount;
        }
    }
}
