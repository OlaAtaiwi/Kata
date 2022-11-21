using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class AfterTaxUPCDiscounter : IAfterTaxDiscount
    {
        private Dictionary<int, double> _upcDiscounts;
        public AfterTaxUPCDiscounter()
        {
            _upcDiscounts = UPCDiscountsList.getUPCDiscounts();
        }

        public double GetDiscountPercent(Product product)
        {
            if (_upcDiscounts.ContainsKey(product.UPC))
                return _upcDiscounts[product.UPC];
            else
                return 0;
        }

        public double CalculateDiscountsAfter(Product product, double Price)
        {
            if (_upcDiscounts.ContainsKey(product.UPC))
                return Math.Round(Price * (_upcDiscounts[product.UPC] / 100), 2);
            else
                return 0;
        }
    }
}
