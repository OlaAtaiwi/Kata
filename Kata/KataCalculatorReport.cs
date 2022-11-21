using System;

namespace Kata
{
    public class KataCalculatorReport
    {
        public static void DiscountReport(KataCalculator kata, Product product, ListOfDiscountsWithDetails discounts)
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            DiscountCalculator discountCalculator = new DiscountCalculator(discounts);
            Console.WriteLine(product.ToString());
            BeforeTaxDiscountReport(discountCalculator.beforeTaxDiscounter, product);
            taxReport(taxCalculator, product.Price - discountCalculator.GetBeforeTaxDiscountAmount(product));
            AfterTaxDiscountReport(discountCalculator.afterTaxDiscounter, product, product.Price - discountCalculator.GetBeforeTaxDiscountAmount(product));
            Console.WriteLine($"Product Original Price={product.Price} ");
            Console.WriteLine($"Product Final Price={product.FinalPrice} ");
            Console.WriteLine($"Product Total Discount Amount ={product.DiscountAmount} ");
        }

        public static void BeforeTaxDiscountReport(BeforeTaxDiscounter before, Product product)
        {
            if (before != null)
                Console.WriteLine($"Before Tax discounts:{ before.GetDiscountPercent(product)}% and Discount Amount={before.CalculateDiscountsBefore(product)}");
            else
                Console.WriteLine("No Discounts Before Tax is applied");
        }

        public static void taxReport(TaxCalculator taxCal, double price)
        {
            Console.WriteLine($"Tax ={taxCal.Tax}%, and the Tax Ammount={taxCal.CalculateTaxAmount(price)}$");
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
