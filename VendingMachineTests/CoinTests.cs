﻿using System;
using VendingMachine;
using Xunit;
using VendingMachine.Managers;

namespace VendingMachineTests
{
    public class CoinTests
    {
        [Fact]
        public void WhenNickelIsInsertedTheCoinIsRecognized()
        {
            //arrange 
            CoinManager coinManager = new CoinManager();

            //act
            CoinType coinType = coinManager.Identify(5.00, 21.21);

            //assert
            Assert.Equal(CoinType.Nickel,coinType);
        }

        [Fact]
        public void WhenDimeIsInsertedTheCoinIsRecognized()
        {
            CoinManager coinManager = new CoinManager();

            CoinType coinType = coinManager.Identify(2.268, 17.9);

            Assert.Equal(CoinType.Dime, coinType);
        }

        [Fact]
        public void WhenQuarterIsInsertedTheCoinIsRecognized()
        {
            CoinManager coinManager = new CoinManager();

            CoinType coinType = coinManager.Identify(5.670, 24.26);

            Assert.Equal(CoinType.Quarter, coinType);
        }

    }
}
