using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public interface IAfterTaxDiscount
    {
        public double CalculateDiscountsAfter(Product product, double Price);
    }
}
