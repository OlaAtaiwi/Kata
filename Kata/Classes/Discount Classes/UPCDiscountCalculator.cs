using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class UPCDiscountCalculator : IDiscount
    {
        private Dictionary<int,double> UPCDiscounts;
        public UPCDiscountCalculator()
        {
            UPCDiscounts = UPCDiscountsList.getUPCDiscounts();
        }
        public double CalculateDiscountAmount(Product product)
        {
            if (UPCDiscounts.ContainsKey(product.UPC))
                return Math.Round(product.Price * (UPCDiscounts[product.UPC] / 100), 2);
            else
                return 0;
        }

        public double GetDiscountPercent(Product product)
        {
            if (UPCDiscounts.ContainsKey(product.UPC))
                return UPCDiscounts[product.UPC];
            else
                return 0;
        }
    }
}
