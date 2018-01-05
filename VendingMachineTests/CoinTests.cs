﻿using System;
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
        [InlineData(dimeValue, dimeWeight, dimeDiameter)]
        [InlineData(nickelValue, nickelWeight, nickelDiameter)]
        [InlineData(quarterValue, quarterWeight, quarterDiameter)]
        [InlineData(pennyValue, pennyWeight, pennyDiameter)]
        public void WhenValidCoinIsInsertedTheValueIsUpdatedWhenThereAreNoCoinsInsertedBefore(decimal coinValue,
            double weight, double diameter)
        {
            machine.InsertCoin(weight, diameter);

            Assert.Equal(dimeValue, machine.CurrentValue);
        }
    }
}
