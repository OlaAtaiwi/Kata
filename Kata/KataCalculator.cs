using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class KataCalculator
    {
        private Product _product;
        private DiscountCalculator _discountsCalculator = null;
        private TaxCalculator _taxCalculator;
        private ExpensesCalculator _expensesCalculator = null;
        public KataCalculator(Product product, ListOfDiscountsWithDetails discounts, List<Expenses> expenses)
        {
            this._product = product;
            this._taxCalculator = new TaxCalculator();
            if (discounts != null)
                _discountsCalculator = new DiscountCalculator(discounts);
            if (expenses.Count > 0)
                _expensesCalculator = new ExpensesCalculator(expenses);
        }

        public void CalculatePrice()
        {
            double beforeTaxDiscountAmount = 0, totalDiscountAmount = 0;
            if (_discountsCalculator != null)
            {
                beforeTaxDiscountAmount = _discountsCalculator.GetBeforeTaxDiscountAmount(_product);
                totalDiscountAmount = _discountsCalculator.CalculateDiscount(_product);
            }
            var taxAmount = _taxCalculator.CalculateTaxAmount(_product.Price - beforeTaxDiscountAmount);
            _product.TaxAmount = taxAmount;
            _product.DiscountAmount = totalDiscountAmount;
            double expenses = 0;
            if (_expensesCalculator != null)
                expenses = _expensesCalculator.CalculateExpensesAmounts(_product.Price);
            _product.FinalPrice = _product.Price + _product.TaxAmount - _product.DiscountAmount + expenses;
        }
    }
}
