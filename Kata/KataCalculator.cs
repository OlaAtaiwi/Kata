using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class KataCalculator
    {
        private Product _product;
        private DiscountCalculator _discountsCalculator;
        private TaxCalculator _taxCalculator;
        public KataCalculator(Product product,ListOfDiscountsWithDetails discounts)
        {
            this._product = product;
            this._taxCalculator = new TaxCalculator();
            _discountsCalculator = new DiscountCalculator(discounts);
        }

        public void CalculatePrice()
        {
            var taxAmount = _taxCalculator.CalculateTaxAmount(_product.Price - _discountsCalculator.GetBeforeTaxDiscountAmount(_product));
            _product.TaxAmount = taxAmount;
            _product.DiscountAmount =_discountsCalculator.CalculateDiscount(_product);
            _product.FinalPrice = _product.Price + _product.TaxAmount -_product.DiscountAmount;
        }
    }
}
