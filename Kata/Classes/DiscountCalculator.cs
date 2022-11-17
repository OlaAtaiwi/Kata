using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class DiscountCalculator
    {
        private Dictionary<int, double> selectiveDiscounts;
        public double defaultDiscount { get; set; }
        public double upcDiscount { get; set; }
        public DiscountCalculator()
        {
            defaultDiscount = 15;
            selectiveDiscounts = UPCDiscounts.getUPCDiscounts();
            upcDiscount = 0;
        }
        public double CalculateDiscountAmount(Product product)
        {
            return DefaultDiscount(product) + SelectiveDiscount(product);
        }

        public double DefaultDiscount(Product product)
        {
            return Math.Round(product.Price * (Validate(defaultDiscount)), 2);
        }
        public double SelectiveDiscount(Product product)
        {
            if (selectiveDiscounts.ContainsKey(product.UPC))
            {
                upcDiscount = selectiveDiscounts[product.UPC];
                return Math.Round(product.Price * (Validate(selectiveDiscounts[product.UPC])), 2);
            }
            return 0;

        }
        private static double Validate(double Number)
        {
            if (Number > 100 || Number < 0)
                throw new ArgumentException("Invalid Discount! Discount must be between 0 and 100");
            return Number / 100;
        }
    }
}
