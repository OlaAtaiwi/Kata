using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class AfterTaxDiscounter : IAfterTaxDiscount
    {
        private AfterTaxDefaultDiscounter _afterDefault;
        private AfterTaxUPCDiscounter _afterUPC;
        public AfterTaxDiscounter(List<DiscountDetails> listOfDiscounts)
        {
            if (listOfDiscounts == null)
            {
                _afterDefault = null;
                _afterUPC = null;
            }
            else
            {
                GenerateDiscounters(listOfDiscounts);
            }
        }

        private void GenerateDiscounters(List<DiscountDetails> listOfDiscounts)
        {
            if (listOfDiscounts.Count == 2)
            {
                _afterDefault = new AfterTaxDefaultDiscounter();
                _afterUPC = new AfterTaxUPCDiscounter();
            }
            else
            {
                if (listOfDiscounts.Count == 1)
                {
                    if (listOfDiscounts[0].DiscountType == DiscountType.Default)
                    {
                        _afterDefault = new AfterTaxDefaultDiscounter();
                        _afterUPC = null;
                    }
                    else
                    {
                        _afterDefault = null;
                        _afterUPC = new AfterTaxUPCDiscounter();
                    }
                }
            }
        }

        public double GetDiscountPercent(Product product)
        {
            double defaultAmount = 0, upcAmount = 0;
            if (_afterDefault != null)
                defaultAmount = _afterDefault.Discount;
            if (_afterUPC != null)
                upcAmount = _afterUPC.GetDiscountPercent(product);
            return defaultAmount + upcAmount;
        }

        public double CalculateDiscountsAfter(Product product, double Price)
        {
            double defaultAmount = 0, upcAmount = 0;
            if (_afterDefault != null)
                defaultAmount = _afterDefault.CalculateDiscountsAfter(product, Price);
            if (_afterUPC != null)
                upcAmount = _afterUPC.CalculateDiscountsAfter(product, Price);
            return defaultAmount + upcAmount;

        }
    }
}
