using CapitalGainsTaxCalculator.Strategies;

namespace CapitalGainsTaxCalculator.Models;

    public class Operation(decimal unitCost, int quantity, ITaxStrategy taxStrategy)
    {
        public decimal UnitCost { get; private set; } = unitCost;
        public int Quantity { get; private set; } = quantity;
        public ITaxStrategy TaxStrategy { get; private set; } = taxStrategy;

        public decimal CalculateTax(decimal previousProfit)
        {
            var tax = TaxStrategy.CalculateTax(UnitCost, Quantity, previousProfit);
            return tax;
        }
    }