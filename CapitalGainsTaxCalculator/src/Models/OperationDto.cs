using CapitalGainsTaxCalculator.Strategies;

namespace CapitalGainsTaxCalculator.Models;

public class OperationDto
{
    public decimal UnitCost { get; set; }
    public int Quantity { get; set; }
    public string TaxStrategy { get; set; }
}

public static class OperationMapper
{
    private static Operation ToOperation(this OperationDto dto)
    {
        ITaxStrategy taxStrategy = dto.TaxStrategy.ToLower() switch
        {
            "buy" => new BuyTaxStrategy(),
            "sell" => new SellTaxStrategy(),
            _ => throw new InvalidOperationException("Estratégia de imposto inválida.")
        };

        return new Operation(dto.UnitCost, dto.Quantity, taxStrategy);
    }
    
    public static List<Operation> MapToOperations(List<OperationDto> operationsDto)
    {
        return operationsDto.Select(dto => dto.ToOperation()).ToList();
    }
}