using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class BeforeTaxAdditiveDiscounter : IBeforeTaxDiscount
    {
        private BeforeTaxDefaultDiscounter _beforeDefault;
        private BeforeTaxUPCDiscounter _beforeUPC;
        public BeforeTaxAdditiveDiscounter(List<DiscountDetails> listOfDiscounts)
        {
            if (listOfDiscounts == null)
            {
                _beforeDefault = null;
                _beforeUPC = null;
            }
            else
            {
                GenerateDiscounters(listOfDiscounts);
            }
        }

        private void GenerateDiscounters(List<DiscountDetails> listOfDiscounts)
        {
            if (listOfDiscounts.Count == 2)
            {
                _beforeDefault = new BeforeTaxDefaultDiscounter();
                _beforeUPC = new BeforeTaxUPCDiscounter();
            }
            else
            {
                if (listOfDiscounts.Count == 1)
                {
                    if (listOfDiscounts[0].DiscountType == DiscountType.Default)
                    {
                        _beforeDefault = new BeforeTaxDefaultDiscounter();
                        _beforeUPC = null;
                    }
                    else
                    {
                        _beforeDefault = null;
                        _beforeUPC = new BeforeTaxUPCDiscounter();
                    }
                }
            }
        }

        public double CalculateDiscountsBefore(Product product,double price)
        {
            double defaultAmount = 0, upcAmount = 0;
            if (_beforeDefault != null)
                defaultAmount = _beforeDefault.CalculateDiscountsBefore(product,price);
            if (_beforeUPC != null)
                upcAmount = _beforeUPC.CalculateDiscountsBefore(product,price);
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
