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

        //#region Tests

        //[Fact]
        //public void WhenColaIsSelectedAndEnoughMoneyHasBeenInsertedTheDisplaySaysThankYou()
        //{
        //    SimulateBuyingCola();

        //    Assert.Equal(THANK_YOU_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenChipsIsSelectedAndEnoughMoneyHasBeenInsertedTheDisplaySaysThankYou()
        //{
        //    SimulateBuyingChips();

        //    Assert.Equal(THANK_YOU_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenCandyIsSelectedAndEnoughMoneyHasBeenInsertedTheDisplaySaysThankYou()
        //{
        //    SimulateBuyingCandy();

        //    Assert.Equal(THANK_YOU_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheDisplayIsCheckedAndAColaWasRecentlyDispensedTheDisplaySaysInsertCoins()
        //{
        //    SimulateBuyingCola();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheDisplayIsCheckedAndChipsWasRecentlyDispensedTheDisplaySaysInsertCoins()
        //{
        //    SimulateBuyingChips();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheDisplayIsCheckedAndCandyWasRecentlyDispensedTheDisplaySaysInsertCoins()
        //{
        //    SimulateBuyingCandy();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheDisplayIsCheckedAndAColaWasRecentlyDispensedTheCurrentValueIsReset()
        //{
        //    SimulateBuyingCola();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_VALUE, machine.CurrentValue);
        //}

        //[Fact]
        //public void WhenTheDisplayIsCheckedAndAChipWasRecentlyDispensedTheCurrentValueIsReset()
        //{
        //    SimulateBuyingChips();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_VALUE, machine.CurrentValue);
        //}

        //[Fact]
        //public void WhenTheDisplayIsCheckedAndACandyWasRecentlyDispensedTheCurrentValueIsReset()
        //{
        //    SimulateBuyingCandy();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_VALUE, machine.CurrentValue);
        //}

        //[Fact]
        //public void IfThereIsNotEnoughMoneyForColaInsertedThenTheDisplaySaysPriceAndValue()
        //{
        //    SimulateBuyingColaNotEnoughCredit();

        //    Assert.Equal(PRICE_DISPLAY_PREFIX + colaValue, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void IfThereIsNotEnoughMoneyForChipsInsertedThenTheDisplaySaysPriceAndValue()
        //{
        //    SimulateBuyingChipsNotEnoughCredit();

        //    Assert.Equal(PRICE_DISPLAY_PREFIX + chipsValue, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void IfThereIsNotEnoughMoneyForCandyInsertedThenTheDisplaySaysPriceAndValue()
        //{
        //    SimulateBuyingCandyNotEnoughCredit();

        //    Assert.Equal(PRICE_DISPLAY_PREFIX + chipsValue, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void SubsequentDisplayChecksWillDisplayInsertCoinIfThePriceHasBeenDisplayedAlreadyWhenChipsIsSelected()
        //{
        //    SimulateBuyingChipsNotEnoughCredit();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void SubsequentDisplayChecksWillDisplayInsertCoinIfThePriceHasBeenDisplayedAlreadyWhenColaIsSelected()
        //{
        //    SimulateBuyingColaNotEnoughCredit();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void SubsequentDisplayChecksWillDisplayInsertCoinIfThePriceHasBeenDisplayedAlreadyWhenCandyIsSelected()
        //{
        //    SimulateBuyingCandyNotEnoughCredit();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void SubsequentDisplayChecksWillDisplayTheCurrentAmountIfThePriceHasBeenDisplayedAndInsertCoinHasBeenDisplayedWhenColaIsSelected()
        //{
        //    SimulateBuyingColaNotEnoughCredit();

        //    machine.CheckDisplay();

        //    machine.CheckDisplay();

        //    Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        //}

        //[Fact]
        //public void SubsequentDisplayChecksWillDisplayTheCurrentAmountIfThePriceHasBeenDisplayedAndInsertCoinHasBeenDisplayedWhenChipsIsSelected()
        //{
        //    SimulateBuyingChipsNotEnoughCredit();

        //    machine.CheckDisplay();

        //    machine.CheckDisplay();

        //    Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        //}

        //[Fact]
        //public void SubsequentDisplayChecksWillDisplayTheCurrentAmountIfThePriceHasBeenDisplayedAndInsertCoinHasBeenDisplayedWhenCandyIsSelected()
        //{
        //    SimulateBuyingCandyNotEnoughCredit();

        //    machine.CheckDisplay();

        //    machine.CheckDisplay();

        //    Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayInsertCoinForCola()
        //{
        //    SimulateColaGoingOutOfStock();

        //    machine.ReturnButtonPressed();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayInsertCoinForChips()
        //{
        //    SimulateChipsGoingOutOfStock();

        //    machine.ReturnButtonPressed();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayInsertCoinForCandy()
        //{
        //    SimulateCandyGoingOutOfStock();

        //    machine.ReturnButtonPressed();

        //    machine.CheckDisplay();

        //    Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        //

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayValueInserted(ProductType product, decimal value)
        {
            SimulateProductSoldOutState(product, value);
            machine.InsertCoin(dimeWeight, dimeDiameter);

            machine.CheckDisplay();

            Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        }

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void WhenTheItemSelectedByCustomerIsOutOfStockItWillDisplaySoldOut(ProductType product, decimal value)
        {
            SimulateProductSoldOutState(product, value);

            Assert.Equal(SOLD_OUT_DISPLAY, machine.CurrentDisplay);
        }

        private void SimulateProductSoldOutState(ProductType product, decimal value)
        {
            machine.CurrentValue = value;
            machine.SelectProduct(product);
            machine.CurrentValue = value;
            machine.SelectProduct(product);
            machine.CurrentValue = value;
            machine.SelectProduct(product);
        }

        
    }
}
