using CapitalGainsTaxCalculator.Models;
using CapitalGainsTaxCalculator.Strategies;

namespace CapitalGainsTaxCalculatorTest.UnitTests
{
    public class OperationTests
    {
        [Fact]
        public void TestBuyOperationTax()
        {
            var operation = new Operation(100.00m, 50, new BuyTaxStrategy());
            var tax = operation.CalculateTax(0.00m);
            Assert.Equal(0.00m, tax);
        }

        [Fact]
        public void TestSellOperationTax()
        {
            var operation = new Operation(150.00m, 30, new SellTaxStrategy());
            var tax = operation.CalculateTax(0.00m);
            Assert.True(tax > 0.00m); 
        }
    }
}