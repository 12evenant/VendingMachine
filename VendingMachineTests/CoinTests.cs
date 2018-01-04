using System;
using VendingMachine;
using Xunit;
using VendingMachine.Managers;

namespace VendingMachineTests
{
    public class CoinTests
    {
        protected CoinManager coinManager;

        public CoinTests()
        {
            coinManager = new CoinManager();
        }

        [Theory]
        [InlineData(CoinType.Nickel, 5.00, 21.21)]
        [InlineData(CoinType.Dime, 2.268, 17.9)]
        [InlineData(CoinType.Quarter, 5.670, 24.26)]
        [InlineData(CoinType.Unacceptable, 3.11, 19.05)]
        public void WhenValidCoinIsInsertedTheCoinIsRecognized(CoinType insertedCoinType, double weight, double diameter)
        {
            CoinType coinType = coinManager.Identify(weight, diameter);

            Assert.Equal(coinType, insertedCoinType);
        }
    }
}
