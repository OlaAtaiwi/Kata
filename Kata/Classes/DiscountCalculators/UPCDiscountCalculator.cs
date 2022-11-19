using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class UPCDiscountCalculator : IDiscount
    {
        private Dictionary<int,double> _upcDiscounts;

        public UPCDiscountCalculator()
        {
            _upcDiscounts = UPCDiscountsList.getUPCDiscounts();
        }

        public double CalculateDiscountAmount(Product product)
        {
            if (_upcDiscounts.ContainsKey(product.UPC))
                return Math.Round(product.Price * (_upcDiscounts[product.UPC] / 100), 2);
            else
                return 0;
        }

        public double GetDiscountPercent(Product product)
        {
            if (_upcDiscounts.ContainsKey(product.UPC))
                return _upcDiscounts[product.UPC];
            else
                return 0;
        }
    }
}
