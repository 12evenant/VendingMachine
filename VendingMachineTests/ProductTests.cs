using VendingMachine.Managers;
using Xunit;

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
            machine.CandySelected();

            machine.CheckDisplay();

            Assert.Equal("PRICE : " + colaValue, machine.CurrentDisplay);
        }


    }
}
