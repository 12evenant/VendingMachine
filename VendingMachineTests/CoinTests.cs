using System;
using VendingMachine;
using Xunit;
using VendingMachine.Managers;

namespace VendingMachineTests
{
    public class CoinTests : TestBase
    {
        protected CoinManager coinManager;
        protected Machine machine;

        public CoinTests()
        {
            coinManager = new CoinManager();
            machine = new Machine();
        }

        [Theory]
        [InlineData(CoinType.Nickel, nickelWeight, nickelDiameter)]
        [InlineData(CoinType.Dime, dimeWeight, dimeDiameter)]
        [InlineData(CoinType.Quarter, quarterWeight, quarterDiameter)]
        [InlineData(CoinType.Unacceptable, pennyWeight, pennyDiameter)]
        public void WhenValidCoinIsInsertedTheCoinIsRecognized(CoinType insertedCoinType, double weight, double diameter)
        {
            CoinType coinType = coinManager.Identify(weight, diameter);

            Assert.Equal(coinType, insertedCoinType);
        }

        [Fact]
        public void WhenDimeIsInsertedTotalAmountIsUpdated()
        {
            machine.InsertCoin(dimeWeight, dimeDiameter);

            Assert.Equal(dimeValue, machine.CurrentValue);
        }

        [Theory]
        [InlineData(0.10, dimeWeight, dimeDiameter)]
        [InlineData(0.05, nickelWeight, nickelDiameter)]
        [InlineData(0.25, quarterWeight, quarterDiameter)]
        [InlineData(0.01, pennyWeight, pennyDiameter)]
        public void WhenValidCoinIsInsertedTheValueIsUpdatedWhenThereAreNoCoinsInsertedBefore(decimal coinValue,
            double weight, double diameter)
        {
            machine.InsertCoin(weight, diameter);

            Assert.Equal(coinValue, machine.CurrentValue);
        }
    }
}
