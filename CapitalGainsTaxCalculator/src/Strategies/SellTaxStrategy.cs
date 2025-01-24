namespace CapitalGainsTaxCalculator.Strategies;

    public class SellTaxStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal unitCost, int quantity, decimal previousProfit)
        {
            var totalValue = unitCost * quantity;
            var profit = totalValue - previousProfit;

            if (profit > 0) 
                return profit * 0.15m;
            
            return 0;
        }
    }