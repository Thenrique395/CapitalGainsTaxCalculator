using CapitalGainsTaxCalculator.Models;
using CapitalGainsTaxCalculator.Strategies;

namespace CapitalGainsTaxCalculator.Services;

public class CapitalGainsTaxCalculator
{
    private decimal _previousProfit = 0.00m;

    public List<TaxCalculationResult> ProcessOperations(List<Operation> operations)
    {
        var results = new List<TaxCalculationResult>();
        try
        {
            foreach (var operation in operations)
            {
                var (tax, totalValue) = CalculateTaxAndTotalValue(operation);
                results.Add(new TaxCalculationResult(tax, totalValue));

                if (operation.TaxStrategy is SellTaxStrategy)
                    UpdateProfitAfterSale(totalValue, tax);
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erro ao processar a operação: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }

        return results;
    }

    private (decimal tax, decimal totalValue) CalculateTaxAndTotalValue(Operation operation)
    {
        try
        {
            var tax = operation.CalculateTax(_previousProfit);
            var totalValue = operation.UnitCost * operation.Quantity;
            return (tax, totalValue);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Erro ao calcular imposto ou valor total.", ex);
        }
    }

    private void UpdateProfitAfterSale(decimal totalValue, decimal tax)
    {
        try
        {
            var profit = totalValue - _previousProfit;
            _previousProfit = profit > 0 ? profit - tax : profit - tax;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Erro ao atualizar o lucro após a venda.", ex);
        }
    }
}