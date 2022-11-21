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
            Console.WriteLine($"Before Tax discounts:{ before.GetDiscountPercent(product)}% and Discount Amount={before.CalculateDiscountsBefore(product)}");
        }

        public static void taxReport(TaxCalculator taxCal, double price)
        {
            Console.WriteLine($"Tax ={taxCal.Tax}%, and the Tax Ammount={taxCal.CalculateTaxAmount(price)}$");
        }

        public static void AfterTaxDiscountReport(AfterTaxDiscounter after, Product product, double price)
        {
            Console.WriteLine($"After Tax discounts:{ after.GetDiscountPercent(product)}% and Discount Amount={after.CalculateDiscountsAfter(product, price)}");
        }
    }
}
