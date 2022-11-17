using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class DiscountCalculator:IDiscount
    {
        public DefaultDiscountCalculator defaultDiscount;
        public UPCDiscountCalculator UPCDiscount;
        public DiscountCalculator()
        {
            defaultDiscount = new DefaultDiscountCalculator();
            UPCDiscount = new UPCDiscountCalculator();
        }
        public DiscountCalculator(double defaultDiscount)
        {
            this.defaultDiscount = new DefaultDiscountCalculator(defaultDiscount);
            UPCDiscount = new UPCDiscountCalculator();
        }
        public double CalculateDiscountAmount(Product product)
        {
            return Math.Round(defaultDiscount.CalculateDiscountAmount(product) + UPCDiscount.CalculateDiscountAmount(product),2);
        }
        public double GetDiscountPercent(Product product)
        {
            return (defaultDiscount.GetDiscountPercent(product) + UPCDiscount.GetDiscountPercent(product));
        }
    }
}
