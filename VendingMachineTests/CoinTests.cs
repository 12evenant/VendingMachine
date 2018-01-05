using System;
using VendingMachine;
using Xunit;
using VendingMachine.Managers;

namespace VendingMachineTests
{
    public class CoinTests : TestBase
    {
        protected CoinManager coinManager;

        public CoinTests()
        {
            coinManager = new CoinManager();
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
    }
}
