using System;
using Xunit;


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
            CoinType coinType = coinManager.Identify(5.00);

            //assert
            Assert.Equal(coinType,CoinType.Nickel);

        }
    }
}
