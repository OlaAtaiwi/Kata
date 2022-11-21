namespace Kata
{
    public class DiscountDetails
    {
        public DiscountPrecedence Precedence { get; set; }
        public DiscountType DiscountType { get; set; }

        public DiscountDetails(DiscountPrecedence precedence,DiscountType discountType)
        {
            Precedence = precedence;
            DiscountType = discountType;
        }
    }
}
