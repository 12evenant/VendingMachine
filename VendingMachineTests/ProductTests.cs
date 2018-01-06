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

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void WhenTheDisplayIsCheckedAndAProductWasRecentlyDispensedTheCurrentValueIsReset(ProductType product,
            decimal value)
        {
            SimulateProductSold(product, value);

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_VALUE, machine.CurrentValue);
        }

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void IfThereIsNotEnoughMoneyForAProductThenTheDisplaySaysPriceAndValue(ProductType product,
            decimal value)
        {
            SimulateSelectingProductNotEnoughCredit(product, value);

            Assert.Equal(PRICE_DISPLAY_PREFIX + value, machine.CurrentDisplay);
        }

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void SubsequentDisplayChecksWillDisplayInsertCoinIfThePriceHasBeenDisplayedAlready(ProductType product,
            decimal value)
        {
            SimulateSelectingProductNotEnoughCredit(product, value);

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void
            SubsequentDisplayChecksWillDisplayTheCurrentAmountIfThePriceHasBeenDisplayedAndInsertCoinHasBeenDisplayed(
            ProductType product, decimal value)
        {
            SimulateSelectingProductNotEnoughCredit(product, value);
            machine.CheckDisplay();

            machine.CheckDisplay();

            Assert.Equal(machine.CurrentValue.ToString(CultureInfo.InvariantCulture), machine.CurrentDisplay);
        }

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayInsertCoin(
            ProductType product, decimal value)
        {
            SimulateProductSoldOutState(product, value);

            machine.CurrentValue = 0;

            machine.CheckDisplay();

            Assert.Equal(DEFAULT_DISPLAY, machine.CurrentDisplay);
        }

        [Theory]
        [ClassData(typeof(ProductSelector))]
        public void WhenTheItemSelectedByCustomerIsOutOfStockAndDisplayIsCheckedItWillDisplayValueInserted(
            ProductType product, decimal value)
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
            SimulateProductSold(product, value);
            SimulateProductSold(product, value);
            SimulateProductSold(product, value);
        }

        private void SimulateProductSold(ProductType product, decimal value)
        {
            machine.CurrentValue = value;
            machine.SelectProduct(product);
        }

        private void SimulateSelectingProductNotEnoughCredit(ProductType product, decimal value)
        {
            machine.CurrentValue = dimeValue;
            machine.SelectProduct(product);
        }
    }
}
