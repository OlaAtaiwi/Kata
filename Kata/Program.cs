using System;
using System.Collections.Generic;
namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("The Little Prince", 12, 20.25);
            ListOfDiscountsWithDetails DiscountsList = GenerateDiscountsList();
            KataCalculator kata = new KataCalculator(product, DiscountsList);
            kata.CalculatePrice();
            KataCalculatorReport.DiscountReport(kata, product, DiscountsList);
            Console.WriteLine("______________________________________________________________________________");

        }

        private static ListOfDiscountsWithDetails GenerateDiscountsList()
        {
            List<DiscountDetails> ListOfDiscounts = new List<DiscountDetails>() { new DiscountDetails(DiscountPrecedence.Before, DiscountType.Default), new DiscountDetails(DiscountPrecedence.After, DiscountType.UPC) };
            ListOfDiscountsWithDetails DiscountsList = new ListOfDiscountsWithDetails(ListOfDiscounts);
            return DiscountsList;
        }
    }
}
