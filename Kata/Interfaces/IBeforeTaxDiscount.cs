using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    interface IBeforeTaxDiscount
    {
        public double CalculateDiscountsBefore(Product product);
    }
}
