using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class BeforeTaxDiscounter : IBeforeTaxDiscount
    {
        private BeforeTaxDefaultDiscounter _beforeDefault;
        private BeforeTaxUPCDiscounter _beforeUPC;
        public BeforeTaxDiscounter(BeforeTaxDefaultDiscounter? beforeDefault, BeforeTaxUPCDiscounter? beforeUPC)
        {
            _beforeDefault = beforeDefault ?? null;
            _beforeUPC = beforeUPC ?? null;
        }

        public double CalculateDiscountsBefore(Product product)
        {
            double defaultAmount = 0,upcAmount=0;
            if (_beforeDefault != null)
                defaultAmount = _beforeDefault.CalculateDiscountsBefore(product);
            if(_beforeUPC!=null)
                upcAmount= _beforeUPC.CalculateDiscountsBefore(product);
            return defaultAmount + upcAmount;
        }

        public double GetDiscountPercent(Product product)
        {
            double defaultAmount = 0, upcAmount = 0;
            if (_beforeDefault != null)
                defaultAmount = _beforeDefault.Discount;
            if (_beforeUPC != null)
                upcAmount = _beforeUPC.GetDiscountPercent(product);
            return defaultAmount + upcAmount;
        }
    }
}
