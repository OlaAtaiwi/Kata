using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class KataCalculator
    {
        private Product _product;
        public TaxCalculator taxCalculator { get; private set; }
        private DiscountCalculator _discountCalculator;

        public KataCalculator(Product product)
        {
            _product = product;
            taxCalculator = new TaxCalculator();
            _discountCalculator = new DiscountCalculator();
        }

        public void CalculatePrice()
        {
            _product.TaxAmount = taxCalculator.CalculateTaxAmount(_product);
            _product.DiscountAmount = _discountCalculator.CalculateDiscountAmount(_product);
            _product.FinalPrice = _product.Price + _product.TaxAmount - _product.DiscountAmount;
        }
    }
}
