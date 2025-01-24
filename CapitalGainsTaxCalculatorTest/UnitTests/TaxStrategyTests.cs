using CapitalGainsTaxCalculator.Strategies;

namespace CapitalGainsTaxCalculatorTest.UnitTests
{
    public class TaxStrategyTests
    {
        [Fact]
        public void TestBuyTaxStrategy()
        {
            var strategy = new BuyTaxStrategy();
            var tax = strategy.CalculateTax(100.00m, 50, 0.00m);
            Assert.Equal(0.00m, tax);
        }

        [Fact]
        public void TestSellTaxStrategy()
        {
            var strategy = new SellTaxStrategy();
            var tax = strategy.CalculateTax(150.00m, 30, 0.00m);
            Assert.True(tax > 0.00m);
        }
    }
}