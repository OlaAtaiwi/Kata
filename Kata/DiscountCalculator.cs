using System;
using System.Linq;

namespace Kata
{
    public class DiscountCalculator
    {
        public AfterTaxDiscounter afterTaxDiscounter { get; private set; }
        public BeforeTaxDiscounter beforeTaxDiscounter { get; private set; }
        public DiscountCalculator(ListOfDiscountsWithDetails discounts)
        {
            GenerateDiscountCalculators(discounts);
        }

        private void GenerateDiscountCalculators(ListOfDiscountsWithDetails discounts)
        {
            var before = discounts.ListOfDiscounts.Where(disc => disc.Precedence == DiscountPrecedence.Before).ToList();
            var after = discounts.ListOfDiscounts.Where(disc => disc.Precedence == DiscountPrecedence.After).ToList();
            if (after == null)
                afterTaxDiscounter = null;
            else
            {
                if (after.Count == 2)
                    afterTaxDiscounter = new AfterTaxDiscounter(new AfterTaxDefaultDiscounter(), new AfterTaxUPCDiscounter());
                else
                {
                    if (after[0].DiscountType == DiscountType.Default)
                        afterTaxDiscounter = new AfterTaxDiscounter(new AfterTaxDefaultDiscounter(), null);
                    else
                        afterTaxDiscounter = new AfterTaxDiscounter(null, new AfterTaxUPCDiscounter());
                }
            }
            if (before == null)
                beforeTaxDiscounter = null;
            else
            {
                if (before.Count == 2)
                    beforeTaxDiscounter = new BeforeTaxDiscounter(new BeforeTaxDefaultDiscounter(), new BeforeTaxUPCDiscounter());
                else
                {
                    if (before[0].DiscountType == DiscountType.Default)
                        beforeTaxDiscounter = new BeforeTaxDiscounter(new BeforeTaxDefaultDiscounter(), null);
                    else
                        beforeTaxDiscounter = new BeforeTaxDiscounter(null, new BeforeTaxUPCDiscounter());
                }
            }
        }

        public double CalculateDiscount(Product product)
        {
            var beforeTaxDiscountAmount = beforeTaxDiscounter.CalculateDiscountsBefore(product);
            var afterTaxDiscountAmount = afterTaxDiscounter.CalculateDiscountsAfter(product, product.Price - beforeTaxDiscountAmount);
            return beforeTaxDiscountAmount + afterTaxDiscountAmount;
        }

        public double GetBeforeTaxDiscountAmount(Product product)
        {
            var beforeTaxDiscountAmount = beforeTaxDiscounter.CalculateDiscountsBefore(product);
            return beforeTaxDiscountAmount;
        }
    }
}
