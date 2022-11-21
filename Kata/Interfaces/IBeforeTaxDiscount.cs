using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public interface IBeforeTaxDiscount
    {
        public double CalculateDiscountsBefore(Product product,double price);
    }
}
