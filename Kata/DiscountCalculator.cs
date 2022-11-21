using System;
using System.Linq;
using System.Collections.Generic;
namespace Kata
{
    public class DiscountCalculator
    {
        public IAfterTaxDiscount afterTaxDiscounter { get; private set; }
        public IBeforeTaxDiscount beforeTaxDiscounter { get; private set; }
        public DiscountCalculator(ListOfDiscountsWithDetails discounts,CombiningMethods method)
        {
            if (discounts != null)
            {
                List<DiscountDetails> before;
                if (discounts.ContainsPrecedence(DiscountPrecedence.Before))
                {
                    before = discounts.ListOfDiscounts.Where(disc => disc.Precedence == DiscountPrecedence.Before).ToList();
                    if(method==CombiningMethods.Additive)
                    beforeTaxDiscounter = new BeforeTaxAdditiveDiscounter(before);
                    else
                        beforeTaxDiscounter = new BeforeTaxMultiplicativeDicounter(before);
                }
                List<DiscountDetails> after;
                if (discounts.ContainsPrecedence(DiscountPrecedence.After))
                {
                    after = discounts.ListOfDiscounts.Where(disc => disc.Precedence == DiscountPrecedence.After).ToList();
                    if (method == CombiningMethods.Additive)
                        afterTaxDiscounter = new AfterTaxAdditiveDiscounter(after);
                    else
                        afterTaxDiscounter = new AfterTaxMultiplicativeDiscounter(after);
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
                beforeTaxDiscountAmount = beforeTaxDiscounter.CalculateDiscountsBefore(product,product.Price);
            if (afterTaxDiscounter != null)
                afterTaxDiscountAmount = afterTaxDiscounter.CalculateDiscountsAfter(product, product.Price - beforeTaxDiscountAmount);
            return beforeTaxDiscountAmount + afterTaxDiscountAmount;
        }

        public double GetBeforeTaxDiscountAmount(Product product)
        {
            double beforeTaxDiscountAmount = 0;
            if (beforeTaxDiscounter != null)
                beforeTaxDiscountAmount = beforeTaxDiscounter.CalculateDiscountsBefore(product,product.Price);
            return beforeTaxDiscountAmount;
        }
    }
}
