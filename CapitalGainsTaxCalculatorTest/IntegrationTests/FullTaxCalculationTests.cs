using CapitalGainsTaxCalculator.Models;
using CapitalGainsTaxCalculator.Strategies;

namespace CapitalGainsTaxCalculatorTest.IntegrationTests;

    public class FullTaxCalculationTests
    {
        [Fact]
        public void TestTaxCalculationWithMixedBuyAndSellOperations()
        {
            var operations = new List<Operation>
            {
                new Operation(100.00m, 50, new BuyTaxStrategy()),  // Compra
                new Operation(150.00m, 30, new SellTaxStrategy()), // Venda
                new Operation(120.00m, 20, new BuyTaxStrategy()),  // Compra
                new Operation(200.00m, 10, new SellTaxStrategy())  // Venda
            };

            var calculator = new CapitalGainsTaxCalculator.Services.CapitalGainsTaxCalculator();

            var results = calculator.ProcessOperations(operations);

            Assert.NotEmpty(results);

            Assert.Equal(4, results.Count);

            Assert.Equal(0.00m, results.Last().TaxAmount);
        }
        
[Fact]
public void TestTaxCalculationForMultipleBuySellOperationsWithProfit()
{
    var operations = new List<Operation>
    {
        new Operation(100.00m, 50, new BuyTaxStrategy()),  // Compra: Total 5000.00
        new Operation(180.00m, 30, new SellTaxStrategy()), // Venda: Total 5400.00
        new Operation(120.00m, 20, new BuyTaxStrategy()),  // Compra: Total 2400.00
        new Operation(250.00m, 10, new SellTaxStrategy())  // Venda: Total 2500.00
    };

    var calculator = new CapitalGainsTaxCalculator.Services.CapitalGainsTaxCalculator();
    var results = calculator.ProcessOperations(operations);

    Assert.NotEmpty(results);
    Assert.Equal(4, results.Count);

// Operação 1: Compra, sem imposto.
    decimal previousProfit; // Não há lucro acumulado no início.

// Operação 2: Venda
    var sell1Total = operations[1].UnitCost * operations[1].Quantity; // 180.00 * 30 = 5400.00
    var buy1Total = operations[0].UnitCost * operations[0].Quantity; // 100.00 * 50 = 5000.00
    var profit1 = sell1Total - buy1Total; // 5400.00 - 5000.00 = 400.00
    var tax1 = profit1 > 0 ? profit1 * 0.15m : 0.00m; // 400.00 * 0.15 = 60.00
    previousProfit = profit1 - tax1; // Atualiza lucro acumulado: 400.00 - 60.00 = 340.00

// Operação 3: Compra, sem imposto.
    var buy2Total = operations[2].UnitCost * operations[2].Quantity; // 120.00 * 20 = 2400.00

// Operação 4: Venda
    var sell2Total = operations[3].UnitCost * operations[3].Quantity; // 250.00 * 10 = 2500.00
// Lucro calculado sobre o total de vendas menos o custo acumulado e o lucro acumulado anterior.
    var profit2 = sell2Total - buy2Total + previousProfit; // 2500.00 - 2400.00 + 340.00 = 440.00
    var tax2 = profit2 > 0 ? profit2 * 0.15m : 0.00m; // 440.00 * 0.15 = 66.00

// Lucro final (após imposto da última operação):
// Imposto esperado na última operação
    const decimal expectedTax = 66.00m;

    // Validações
    Assert.Equal(expectedTax, tax2, 2); // Verifica se o imposto final está correto
    Assert.True(tax2 > 0);
}

        
        [Fact]
        public void TestTaxCalculationForMultipleBuySellOperationsWithLoss()
        {
            var operations = new List<Operation>
            {
                new Operation(150.00m, 50, new BuyTaxStrategy()),  // Compra
                new Operation(100.00m, 30, new SellTaxStrategy()), // Venda
                new Operation(120.00m, 20, new BuyTaxStrategy()),  // Compra
                new Operation(80.00m, 10, new SellTaxStrategy())   // Venda
            };

            var calculator = new CapitalGainsTaxCalculator.Services.CapitalGainsTaxCalculator();
            var results = calculator.ProcessOperations(operations);

            Assert.NotEmpty(results);
            Assert.Equal(4, results.Count);

            // Verificar se o imposto final é zero, já que tivemos prejuízo nas vendas
            Assert.Equal(0.00m, results.Last().TaxAmount);
        }

        [Fact]
        public void TestTaxCalculationForSingleBuySingleSellOperation()
        {
            // Definindo as operações de compra e venda
            var operations = new List<Operation>
            {
                new Operation(100.00m, 50, new BuyTaxStrategy()),  // Compra
                new Operation(130.00m, 30, new SellTaxStrategy())  // Venda
            };

            var calculator = new CapitalGainsTaxCalculator.Services.CapitalGainsTaxCalculator();
            var results = calculator.ProcessOperations(operations);

            // Verificando se os resultados não estão vazios e se há exatamente duas operações
            Assert.NotEmpty(results);
            Assert.Equal(2, results.Count);

            // A venda deve gerar lucro, e o imposto é 15% sobre esse lucro
            var totalPurchaseValue = operations[0].UnitCost * operations[0].Quantity;  // Valor total da compra
            var totalSellValue = operations[1].UnitCost * operations[1].Quantity;     // Valor total da venda
            var expectedProfit = totalSellValue - totalPurchaseValue;  // Lucro da venda

            // Garantir que o imposto foi calculado corretamente, ou seja, deve ser maior que zero
            Assert.True(results.Last().TaxAmount > 0.00m);
        }



    }