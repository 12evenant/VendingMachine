﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
