﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class UPCDiscounts
    {
        public static Dictionary<int,double> getUPCDiscounts()
        {
            var dictionary = new Dictionary<int, double>();
            dictionary.Add(12345,15);
            dictionary.Add(123, 10);
            dictionary.Add(12, 15);
            return dictionary;
        }
    }
}
