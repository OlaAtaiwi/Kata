using System.Collections.Generic;

namespace Kata
{
    public class ExpensesCalculator
    {
        private List<Expenses> _listOfExpenses;
        public ExpensesCalculator(List<Expenses> listOfExpenses)
        {
            _listOfExpenses = listOfExpenses;
        }
        public void AddExpenses(Expenses expense)
        {
            _listOfExpenses.Add(expense);
        }
        public double CalculateExpensesAmounts(double price)
        {
            double finalAmount = 0;
            foreach (var item in _listOfExpenses)
            {
                if (item.AmountType == ExpensesAmountType.Percent)
                    finalAmount += (price * (Validator.ValidatePercent(item.Amount) / 100));
                else
                    finalAmount += item.Amount;
            }
            return finalAmount;
        }

    }
}
