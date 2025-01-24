namespace CapitalGainsTaxCalculator.Models
{
    public class TaxCalculationResult(decimal taxAmount, decimal totalValue)
    {
        public decimal TaxAmount { get; set; } = taxAmount;
        public decimal TotalValue { get; set; } = totalValue;
    }
}