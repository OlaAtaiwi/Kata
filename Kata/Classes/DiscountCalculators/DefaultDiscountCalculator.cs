
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class DefaultDiscountCalculator : IDiscount
    {
        const int DiscountPercent = 15;
        public double Discount { get; private set; }

        public DefaultDiscountCalculator()
        {
            Discount = DiscountPercent;
        }

        public DefaultDiscountCalculator(double discount)
        {
            Discount =Validator.ValidatePercent(discount);
        }

        public double CalculateDiscountAmount(Product product)
        {
            return Math.Round(product.Price*(Validator.ValidatePercent(Discount/100)), 2);
        }

        public double GetDiscountPercent(Product product)
        {
            return Discount;
        }
    }
}
