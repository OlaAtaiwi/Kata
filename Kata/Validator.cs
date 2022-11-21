using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class Validator
    {
        public static double ValidatePercent(double number)
        {
            if (number > 100 || number < 0)
                throw new ArgumentException("Invalid Discount! Discount must be between 0 and 100");
            return number;
        }
        public static double ValidatePrice(double Price)
        {
            if (Price > 0)
                return Price;
            throw new ArgumentException("Invalid Price! Price can not be 0 or less");
        }
    }
}
