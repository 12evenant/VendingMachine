using System;
using VendingMachine;
using Xunit;
using Xunit.Extensions;
using VendingMachine.Managers;
using VendingMachineTests.Helper;

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
        [ClassData(typeof(CoinGenerator))]
        public void WhenValidCoinIsInsertedTheCoinIsRecognized(CoinType insertedCoinType,
            double weight, double diameter, decimal coinValue, bool isValid)
        {
            CoinType coinType = coinManager.Identify(weight, diameter);

            Assert.Equal(coinType, insertedCoinType);
        }


        [Theory]
        [ClassData(typeof(CoinGenerator))]
        public void WhenValidCoinIsInsertedTheValueIsUpdatedWhenThereAreNoCoinsInsertedBefore(CoinType insertedCoinType,
            double weight, double diameter, decimal coinValue, bool isValid)
        {
            machine.InsertCoin(weight, diameter);

            if (!isValid)
                Assert.NotEqual(coinValue, machine.CurrentValue);
            else
                Assert.Equal(coinValue, machine.CurrentValue);
        }

        [Theory]
        [ClassData(typeof(CoinGenerator))]
        public void WhenValidCoinIsInsertedTheValueIsUpdatedWhenThereArePreviousCoinsInserted(CoinType insertedCoinType,
            double weight, double diameter, decimal coinValue, bool isValid)
        {        
            machine.CurrentValue = (decimal) 0.05;
            decimal oldValue = machine.CurrentValue;

            machine.InsertCoin(weight, diameter);

            if (!isValid)
                Assert.Equal(oldValue, machine.CurrentValue);
            else
                Assert.Equal(oldValue + coinValue, machine.CurrentValue);
        }

        [Fact]
        public void WhenNoCoinIsInsertedTheMachineShouldDisplayInsertCoins()
        {
            Assert.Equal("INSERT COIN", machine.CurrentDisplay);
        }

    }
}


