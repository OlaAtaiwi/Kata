using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    interface IDiscount
    {
        public double CalculateDiscountAmount(Product product);
        public double GetDiscountPercent(Product product);
    }
}
