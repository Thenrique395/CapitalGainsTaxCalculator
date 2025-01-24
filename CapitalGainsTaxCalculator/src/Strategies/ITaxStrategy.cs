namespace CapitalGainsTaxCalculator.Strategies;

public interface ITaxStrategy
{
    decimal CalculateTax(decimal unitCost, int quantity, decimal previousProfit);
}