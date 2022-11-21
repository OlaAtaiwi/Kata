using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    interface IAfterTaxDiscount
    {
        public double CalculateDiscountsAfter(Product product, double Price);
    }
}
