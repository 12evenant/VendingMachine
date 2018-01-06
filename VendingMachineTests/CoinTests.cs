using System;
using System.Globalization;
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

            CheckResultIsEqual(isValid, oldValue + coinValue, oldValue, machine.CurrentValue);
        }

        [Fact]
        public void WhenNoCoinIsInsertedTheMachineShouldDisplayInsertCoins()
        {
            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Theory]
        [ClassData(typeof(CoinGenerator))]
        public void WhenValidCoinIsInsertedTheMachineShouldUpdateTheDisplay(CoinType insertedCoinType,
            double weight, double diameter, decimal coinValue, bool isValid)
        {
            machine.InsertCoin(weight, diameter);

            CheckResultIsEqual(isValid, machine.CurrentValue.ToString(CultureInfo.InvariantCulture), DEFAULT_DISPLAY,
                machine.CurrentDisplay);
        }

        [Fact]
        public void WhenReturnCoinsIsPressedTheMoneyIsReturned()
        {
            bool coinReturned = coinManager.ReturnCoins(machine.CurrentValue);

            Assert.True(coinReturned);
        }

        [Fact]
        public void WhenReturnCoinsIsPressedTheMoneyIsDeductedFromTheBank()
        {
            decimal valueOfBankBefore = machine.GetValueOfBank();
            machine.InsertCoin(quarterWeight, quarterDiameter);
            machine.InsertCoin(dimeWeight, dimeDiameter);

            machine.ReturnButtonPressed();

            decimal valueOfBankAfter = machine.GetValueOfBank();
            Assert.Equal(valueOfBankBefore - quarterValue - dimeValue, valueOfBankAfter);
        }

        [Fact]
        public void WhenReturnCoinsIsPressedTheDisplayIsUpdatedBackToDefault()
        {
            machine.ReturnButtonPressed();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void WhenTheMachineIsNotAbleToGiveChangeItShouldUpdateTheDisplay()
        {
            machine.CheckIfChangeIsAvailable();

            Assert.Equal(EXACT_CHANGE_ONLY_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void WhenTheMachineIsNotAbleToGiveChangeItShouldReturnFalse()
        {
            bool changeAvailable = coinManager.CheckIfChangeIsAvailable(colaValue, chipsValue, candyValue);

            Assert.False(changeAvailable);
        }

        [Fact]
        public void WhenTheMachineIsAbleToGiveChangeItShouldReturnTrue()
        {
            bool changeAvailable = coinManager.CheckIfChangeIsAvailable(colaValue, chipsValue, candyValue));

            Assert.True(changeAvailable);
        }

    }
}


