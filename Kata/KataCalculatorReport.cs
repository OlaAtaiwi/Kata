using System;
using System.Collections.Generic;

namespace Kata
{
    public class KataCalculatorReport
    {
        public static void DiscountReport(KataCalculator kata, Product product, ListOfDiscountsWithDetails discounts, List<Expenses> expenses,CapCalculator cap)
        {
            Console.WriteLine(product.ToString());
            Console.WriteLine("___________________________________________________________________________");
            DiscountCalculator discountCalculator = new DiscountCalculator(discounts,CombiningMethods.Additive);
            taxReport(product.Price - discountCalculator.GetBeforeTaxDiscountAmount(product));
            CapReport(cap, product);
            Console.WriteLine("________________________________________________________");
            Console.WriteLine($"Product Total Discount Amount ={product.DiscountAmount} ");
            Console.WriteLine("________________________________________________________");
            ExpensesReport(expenses, product);
            Console.WriteLine("________________________________________________________");
            Console.WriteLine($"Product Original Price={product.Price} ");
            Console.WriteLine($"Product Final Price={product.FinalPrice:N2} ");
        }

        private static void ExpensesReport(List<Expenses> expenses, Product product)
        {
            if (expenses.Count > 0)
            {
                Console.WriteLine("Additional Expenses Include: ");
                foreach (var item in expenses)
                {
                    Console.Write($"{item.Description}:");
                    if (item.AmountType == AmountType.Absolute)
                        Console.WriteLine($"{item.Amount}$");
                    else
                        Console.WriteLine($"{item.Amount}% of the product price({product.Price * (Validator.ValidatePercent(item.Amount) / 100)}$)");
                }
            }
            else
            {
                Console.WriteLine("No Additional Expenses");
            }
        }

        public static void taxReport(double price)
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Console.WriteLine($"Tax ={taxCalculator.Tax}%, and the Tax Ammount={taxCalculator.CalculateTaxAmount(price)}$");
        }

        public static void CapReport(CapCalculator cap, Product product)
        {
            Console.Write("Cap Amount: ");
            if (cap.CapAmountType == AmountType.Absolute)
                Console.WriteLine($"{cap.Amount}$ ");
            else
                Console.WriteLine($"{cap.Amount}% of the price({cap.CalculateCap(product)}) ");
        }
    }
}
