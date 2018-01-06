using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Managers
{
    public class CoinManager
    {
        private List<CoinType> CoinBank;

        public CoinManager()
        {
            CoinBank = new List<CoinType>();
        }

        public void AddCoinToBank(CoinType coin)
        {
            CoinBank.Add(coin);
        }

        public CoinType Identify(double weight, double diameter)
        {
            if (weight == NickelConstants.NICKEL_WEIGHT && diameter == NickelConstants.NICKEL_DIAMETER)
            {
                return CoinType.Nickel;
            }
            if (weight == DimeConstants.DIME_WEIGHT && diameter == DimeConstants.DIME_DIAMETER)
            {
                return CoinType.Dime;
            }
            if (weight == QuarterConstants.QUARTER_WEIGHT && diameter == QuarterConstants.QUARTER_DIAMETER)
            {
                return CoinType.Quarter;
            }
            return CoinType.Unacceptable;
        }

        public bool ReturnCoins(decimal currentValue)
        {
            //logic to return coins here?

            return true;
        }

        public bool CheckIfChangeIsAvailable()
        {
            throw new NotImplementedException();
        }

        public decimal GetValueOfBank()
        {
            throw new NotImplementedException();
        }

    }
}
