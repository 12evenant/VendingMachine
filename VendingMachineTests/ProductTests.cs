using System.Globalization;
using VendingMachine.Enums;
using VendingMachine.Managers;
using VendingMachineTests.Helper;
using Xunit;
using static VendingMachine.Enums.ProductType;

namespace VendingMachineTests
{
    public class ProductTests : TestBase
    {
        protected Machine machine;
        protected ProductManager productManager;

        public ProductTests()
        {
            machine = new Machine();
            productManager = new ProductManager();
        }

        [Fact]
        public void WhenColaIsSelectedAndEnoughMoneyHasBeenInsertedTheDisplaySaysThankYou()
        {
            machine.CurrentValue = colaValue;

            machine.ColaSelected();

            Assert.Equal(THANK_YOU_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void WhenChipsIsSelectedAndEnoughMoneyHasBeenInsertedTheDisplaySaysThankYou()
        {
            machine.CurrentValue = chipsValue;

            machine.ChipsSelected();

            Assert.Equal(THANK_YOU_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void WhenCandyIsSelectedAndEnoughMoneyHasBeenInsertedTheDisplaySaysThankYou()
        {
            machine.CurrentValue = candyValue;

            machine.CandySelected();

            Assert.Equal(THANK_YOU_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void WhenTheDisplayIsCheckedAndAColaWasRecentlyDispensedTheDisplaySaysInsertCoins()
        {
            machine.CurrentValue = colaValue;
            machine.ColaSelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void WhenTheDisplayIsCheckedAndChipsWasRecentlyDispensedTheDisplaySaysInsertCoins()
        {
            machine.CurrentValue = chipsValue;
            machine.ChipsSelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void WhenTheDisplayIsCheckedAndCandyWasRecentlyDispensedTheDisplaySaysInsertCoins()
        {
            machine.CurrentValue = candyValue;
            machine.CandySelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void WhenTheDisplayIsCheckedAndAColaWasRecentlyDispensedTheCurrentValueIsReset()
        {
            machine.CurrentValue = colaValue;
            machine.ColaSelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_VALUE, machine.CurrentValue);
        }

        [Fact]
        public void WhenTheDisplayIsCheckedAndAChipWasRecentlyDispensedTheCurrentValueIsReset()
        {
            machine.CurrentValue = chipsValue;
            machine.ChipsSelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_VALUE, machine.CurrentValue);
        }

        [Fact]
        public void WhenTheDisplayIsCheckedAndACandyWasRecentlyDispensedTheCurrentValueIsReset()
        {
            machine.CurrentValue = candyValue;
            machine.CandySelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_VALUE, machine.CurrentValue);
        }

        [Fact]
        public void IfThereIsNotEnoughMoneyForColaInsertedThenTheDisplaySaysPriceAndValue()
        {
            machine.CurrentValue = dimeValue;

            machine.ColaSelected();

            Assert.Equal(PRICE_DISPLAY_PREFIX + colaValue, machine.CurrentDisplay);
        }

        [Fact]
        public void IfThereIsNotEnoughMoneyForChipsInsertedThenTheDisplaySaysPriceAndValue()
        {
            machine.CurrentValue = dimeValue;

            machine.ChipsSelected();

            Assert.Equal(PRICE_DISPLAY_PREFIX + chipsValue, machine.CurrentDisplay);
        }

        [Fact]
        public void IfThereIsNotEnoughMoneyForCandyInsertedThenTheDisplaySaysPriceAndValue()
        {
            machine.CurrentValue = dimeValue;

            machine.ChipsSelected();

            Assert.Equal(PRICE_DISPLAY_PREFIX + chipsValue, machine.CurrentDisplay);
        }

        [Fact]
        public void SubsequentDisplayChecksWillDisplayInsertCoinIfThePriceHasBeenDisplayedAlreadyWhenChipsIsSelected()
        {
            machine.CurrentValue = dimeValue;
            machine.ChipsSelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void SubsequentDisplayChecksWillDisplayInsertCoinIfThePriceHasBeenDisplayedAlreadyWhenColaIsSelected()
        {
            machine.CurrentValue = dimeValue;
            machine.ColaSelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void SubsequentDisplayChecksWillDisplayInsertCoinIfThePriceHasBeenDisplayedAlreadyWhenCandyIsSelected()
        {
            machine.CurrentValue = dimeValue;
            machine.CandySelected();

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Fact]
        public void SubsequentDisplayChecksWillDisplayTheCurrentAmountIfThePriceHasBeenDisplayedAndInsertCoinHasBeenDisplayedWhenColaIsSelected()
        {
            machine.CurrentValue = dimeValue;
            machine.ColaSelected();
            machine.CheckDisplay();

            machine.CheckDisplay();

            Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        }

        [Fact]
        public void SubsequentDisplayChecksWillDisplayTheCurrentAmountIfThePriceHasBeenDisplayedAndInsertCoinHasBeenDisplayedWhenChipsIsSelected()
        {
            machine.CurrentValue = dimeValue;
            machine.ChipsSelected();
            machine.CheckDisplay();

            machine.CheckDisplay();

            Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        }

        [Fact]
        public void SubsequentDisplayChecksWillDisplayTheCurrentAmountIfThePriceHasBeenDisplayedAndInsertCoinHasBeenDisplayedWhenCandyIsSelected()
        {
            machine.CurrentValue = dimeValue;
            machine.CandySelected();
            machine.CheckDisplay();

            machine.CheckDisplay();

            Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        }

        //TODO: Extend This
        //[Theory]
        //[ClassData(typeof(ProductSelector))]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockItWillDisplaySoldOut(ProductType product)
        //{
        //    machine.SelectCandy(product);

        //    Assert.Equal("SOLD OUT", machine.CurrentDisplay);
        //}
    }
}
