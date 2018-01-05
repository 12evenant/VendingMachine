using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Managers
{
    public class CoinManager
    {
        #region Nickel Constants

        private const double _nickelWeight = 5.00;
        private const double _nickelDiameter = 21.21;

        public decimal NickelValue => (decimal)0.05;

        #endregion

        #region Dime Constants

        private const double _dimeWeight = 2.268;
        private const double _dimeDiameter = 17.9;
        public decimal DimeValue => (decimal) 0.10;

        #endregion

        #region Quarter Constants

        private const double _quarterWeight = 5.670;
        private const double _quarterDiameter = 24.26;
        public decimal QuarterValue => (decimal) 0.25;

        #endregion

        public CoinType Identify(double weight, double diameter)
        {
            if (weight == _nickelWeight && diameter == _nickelDiameter)
            {
                return CoinType.Nickel;
            }
            if (weight == _dimeWeight && diameter == _dimeDiameter)
            {
                return CoinType.Dime;
            }
            if (weight == _quarterWeight && diameter == _quarterDiameter)
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

        public bool CheckIfChangeIsAvailable(decimal currentValue)
        {
            //logic to check goes here

            return true;
        }

    }
}
