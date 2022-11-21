using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class ListOfDiscountsWithDetails
    {
        public List<DiscountDetails> ListOfDiscounts { get; set; }
        public ListOfDiscountsWithDetails(List<DiscountDetails> discounts)
        {
            ListOfDiscounts = discounts;
        }
    }
}
