using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class BeforeTaxUPCDiscounter : IBeforeTaxDiscount
    {
        private Dictionary<int, double> _upcDiscounts;
        public BeforeTaxUPCDiscounter()
        {
            _upcDiscounts = UPCDiscountsList.getUPCDiscounts();
        }

        public double CalculateDiscountsBefore(Product product,double price)
        {
            if (_upcDiscounts.ContainsKey(product.UPC))
                return Math.Round(price * (_upcDiscounts[product.UPC] / 100), 2);
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
