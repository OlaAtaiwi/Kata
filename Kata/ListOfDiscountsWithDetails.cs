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
        public bool ContainsPrecedence(DiscountPrecedence precedence)
        {
            if (ListOfDiscounts == null)
                return false;
            foreach (var item in ListOfDiscounts)
            {
                if (item.Precedence == precedence)
                    return true;
            }
            return false;
        }
    }
}
