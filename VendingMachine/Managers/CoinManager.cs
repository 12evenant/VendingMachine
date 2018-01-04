using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Managers
{
    public class CoinManager
    {
        #region Nickel Contants
        private const double nickelWeight = 5.00;
        private const double nickelDiameter = 21.21;
        #endregion

        public CoinType Identify(double weight, double diameter)
        {
            if (weight == nickelWeight && diameter == nickelDiameter)
            {
                return CoinType.Nickel;
            }
            return CoinType.Unacceptable;
        }
    }
}
