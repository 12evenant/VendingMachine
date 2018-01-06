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
        //public void WhenTheItemSelectedByCustomerIsOutOfStockItWillDisplaySoldOutForCola()
        //{
        //    SimulateColaGoingOutOfStock();

        //    Assert.Equal(SOLD_OUT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockItWillDisplaySoldOutForChips()
        //{
        //    SimulateChipsGoingOutOfStock();

        //    Assert.Equal(SOLD_OUT_DISPLAY, machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockItWillDisplaySoldOutForCandy()
        //{
        //    SimulateCandyGoingOutOfStock();

        //    Assert.Equal(SOLD_OUT_DISPLAY, machine.CurrentDisplay);
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
        //}

        //[Fact]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayValueInsertedForCola()
        //{
        //    SimulateCandyGoingOutOfStock();

        //    machine.InsertCoin(dimeWeight, dimeDiameter);

        //    machine.CheckDisplay();

        //    Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayValueInsertedForChips()
        //{
        //    SimulateCandyGoingOutOfStock();

        //    machine.InsertCoin(dimeWeight, dimeDiameter);

        //    machine.CheckDisplay();

        //    Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        //}

        //[Fact]
        //public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayValueInsertedForCandy()
        //{
        //    SimulateCandyGoingOutOfStock();

        //    machine.InsertCoin(dimeWeight, dimeDiameter);

        //    machine.CheckDisplay();

        //    Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        //}

        //#endregion

        //#region Helper Methods

        //private void SimulateColaGoingOutOfStock()
        //{
        //    SimulateBuyingCola();
        //    SimulateBuyingCola();
        //    SimulateBuyingCola();
        //}

        //private void SimulateBuyingCola()
        //{
        //    machine.CurrentValue = colaValue;
        //    machine.ColaSelected();
        //}

        //private void SimulateBuyingColaNotEnoughCredit()
        //{
        //    machine.CurrentValue = dimeValue;
        //    machine.ColaSelected();
        //}

        //private void SimulateChipsGoingOutOfStock()
        //{
        //    SimulateBuyingChips();
        //    SimulateBuyingChips();
        //    SimulateBuyingChips();
        //}

        //private void SimulateBuyingChips()
        //{
        //    machine.CurrentValue = chipsValue;
        //    machine.ChipsSelected();
        //}

        //private void SimulateBuyingChipsNotEnoughCredit()
        //{
        //    machine.CurrentValue = dimeValue;
        //    machine.ChipsSelected();
        //}

        //private void SimulateCandyGoingOutOfStock()
        //{
        //    SimulateBuyingCandy();
        //    SimulateBuyingCandy();
        //    SimulateBuyingCandy();
        //}

        //private void SimulateBuyingCandy()
        //{
        //    machine.CurrentValue = candyValue;
        //    machine.CandySelected();
        //}

        //private void SimulateBuyingCandyNotEnoughCredit()
        //{
        //    machine.CurrentValue = dimeValue;
        //    machine.ChipsSelected();
        //}
        //#endregion

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void WhenTheItemSelectedByCustomerIsOutOfStockItWillDisplaySoldOut(ProductType product, decimal value)
        {
            machine.CurrentValue = value;
            machine.SelectProduct(product);

            Assert.Equal(SOLD_OUT_DISPLAY, machine.CurrentDisplay);
        }
    }
}
