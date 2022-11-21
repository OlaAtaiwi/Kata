using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class AfterTaxDiscounter : IAfterTaxDiscount
    {
        private AfterTaxDefaultDiscounter _afterDefault;
        private AfterTaxUPCDiscounter _afterUPC;
        public AfterTaxDiscounter(AfterTaxDefaultDiscounter? afterDefault, AfterTaxUPCDiscounter? afterUPC)
        {
            _afterDefault = afterDefault ?? null;
            _afterUPC = afterUPC ?? null;
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
