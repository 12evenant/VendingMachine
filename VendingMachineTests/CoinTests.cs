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

        [Fact]
        public void WhenNickelIsInsertedTheCoinIsRecognized()
        {
            //act
            CoinType coinType = coinManager.Identify(5.00, 21.21);

            //assert
            Assert.Equal(CoinType.Nickel,coinType);
        }

        [Fact]
        public void WhenDimeIsInsertedTheCoinIsRecognized()
        {
            CoinType coinType = coinManager.Identify(2.268, 17.9);

            Assert.Equal(CoinType.Dime, coinType);
        }

        [Fact]
        public void WhenQuarterIsInsertedTheCoinIsRecognized()
        {
            CoinType coinType = coinManager.Identify(5.670, 24.26);

            Assert.Equal(CoinType.Quarter, coinType);
        }

        [Fact]
        public void WhenPennyIsInsertedTheCoinIsRecognized()
        {
            CoinType coinType = coinManager.Identify(3.11, 19.05);

            Assert.Equal(CoinType.Unacceptable, coinType);
        }
    }
}
