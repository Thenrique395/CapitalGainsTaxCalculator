namespace CapitalGainsTaxCalculator.Strategies;

    public class BuyTaxStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal unitCost, int quantity, decimal previousProfit)
        {
            return 0.00m;
        }
    }
