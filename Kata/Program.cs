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
            var ExpensesList = CreateExpensesList();
            var cap = new CapCalculator(10, AmountType.Absolute);
            Kata(product, DiscountsList, ExpensesList,cap);
            Console.WriteLine("______________________________________________________________________________");
        }

        private static void Kata(Product product, ListOfDiscountsWithDetails DiscountsList, List<Expenses> ExpensesList, CapCalculator cap)
        {
            KataCalculator kata = new KataCalculator(product, DiscountsList, ExpensesList,CombiningMethods.Multiplicative,cap);
            kata.CalculatePrice();
            KataCalculatorReport.DiscountReport(kata, product, DiscountsList, ExpensesList,cap);
        }

        private static ListOfDiscountsWithDetails GenerateDiscountsList()
        {
            List<DiscountDetails> ListOfDiscounts = new List<DiscountDetails>();
            ListOfDiscounts.Add(new DiscountDetails(DiscountPrecedence.After, DiscountType.Default));
            ListOfDiscounts.Add(new DiscountDetails(DiscountPrecedence.After, DiscountType.UPC));
            ListOfDiscountsWithDetails DiscountsList = new ListOfDiscountsWithDetails(ListOfDiscounts);
            return DiscountsList;
        }

        public static List<Expenses> CreateExpensesList()
        {
            var listOFExpenses = new List<Expenses>();
            listOFExpenses.Add(new Expenses("Packeging", 10, AmountType.Absolute));
            listOFExpenses.Add(new Expenses("transport ", 10, AmountType.Percent));
            return listOFExpenses;
        }
    }
}
