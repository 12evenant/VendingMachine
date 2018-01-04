using System;
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

    }
}
