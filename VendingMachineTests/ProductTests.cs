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
        public void WhenColaIsSelectedAndEnoughMoneyHasBeenInsertedTheProductIsDispensed()
        {
            machine.CurrentValue = (decimal) 1.00;

            machine.ColaSelected();

            Assert.True(machine.ColaDispensing);
        }
    }
}
