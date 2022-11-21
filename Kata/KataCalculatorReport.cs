using System;
using System.Collections.Generic;

namespace Kata
{
    public class KataCalculatorReport
    {
        public static void DiscountReport(KataCalculator kata, Product product, ListOfDiscountsWithDetails discounts, List<Expenses> expenses)
        {
            Console.WriteLine(product.ToString());
            Console.WriteLine("___________________________________________________________________________");
            DiscountCalculator discountCalculator = new DiscountCalculator(discounts);
            BeforeTaxDiscountReport(discountCalculator.beforeTaxDiscounter, product);
            Console.WriteLine("________________________________________________________");
            taxReport(product.Price - discountCalculator.GetBeforeTaxDiscountAmount(product));
            Console.WriteLine("________________________________________________________");
            AfterTaxDiscountReport(discountCalculator.afterTaxDiscounter, product, product.Price - discountCalculator.GetBeforeTaxDiscountAmount(product));
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
                    if (item.AmountType == ExpensesAmountType.Absolute)
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

        public static void BeforeTaxDiscountReport(BeforeTaxDiscounter before, Product product)
        {
            if (before != null)
                Console.WriteLine($"Before Tax discounts:{ before.GetDiscountPercent(product)}% and Discount Amount={before.CalculateDiscountsBefore(product)}");
            else
                Console.WriteLine("No Discounts Before Tax is applied");
        }

        public static void taxReport(double price)
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Console.WriteLine($"Tax ={taxCalculator.Tax}%, and the Tax Ammount={taxCalculator.CalculateTaxAmount(price)}$");
        }

        public static void AfterTaxDiscountReport(AfterTaxDiscounter after, Product product, double price)
        {
            if (after != null)
                Console.WriteLine($"After Tax discounts:{ after.GetDiscountPercent(product)}% and Discount Amount={after.CalculateDiscountsAfter(product, price)}");
            else
                Console.WriteLine("No Discounts After Tax is applied");
        }
    }
}
