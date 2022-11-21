using System;
using System.Linq;
using System.Collections.Generic;
namespace Kata
{
    public class DiscountCalculator
    {
        public AfterTaxDiscounter afterTaxDiscounter { get; private set; }
        public BeforeTaxDiscounter beforeTaxDiscounter { get; private set; }
        public DiscountCalculator(ListOfDiscountsWithDetails discounts)
        {
            if (discounts != null)
            {
                List<DiscountDetails> before;
                if (discounts.ContainsPrecedence(DiscountPrecedence.Before))
                {
                    before = discounts.ListOfDiscounts.Where(disc => disc.Precedence == DiscountPrecedence.Before).ToList();
                    beforeTaxDiscounter = new BeforeTaxDiscounter(before);
                }
                List<DiscountDetails> after;
                if (discounts.ContainsPrecedence(DiscountPrecedence.After))
                {
                    after = discounts.ListOfDiscounts.Where(disc => disc.Precedence == DiscountPrecedence.After).ToList();
                    afterTaxDiscounter = new AfterTaxDiscounter(after);
                }
            }
            else
            {
                beforeTaxDiscounter = null;
                afterTaxDiscounter = null;
            }
        }

        public double CalculateDiscount(Product product)
        {
            double beforeTaxDiscountAmount = 0, afterTaxDiscountAmount = 0;
            if (beforeTaxDiscounter != null)
                beforeTaxDiscountAmount = beforeTaxDiscounter.CalculateDiscountsBefore(product);
            if (afterTaxDiscounter != null)
                afterTaxDiscountAmount = afterTaxDiscounter.CalculateDiscountsAfter(product, product.Price - beforeTaxDiscountAmount);
            return beforeTaxDiscountAmount + afterTaxDiscountAmount;
        }

        public double GetBeforeTaxDiscountAmount(Product product)
        {
            double beforeTaxDiscountAmount = 0;
            if (beforeTaxDiscounter != null)
                beforeTaxDiscountAmount = beforeTaxDiscounter.CalculateDiscountsBefore(product);
            return beforeTaxDiscountAmount;
        }
    }
}
