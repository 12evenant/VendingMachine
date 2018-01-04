using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Managers
{
    public class CoinManager
    {
        public CoinType Identify(double weight)
        {
            if (weight == 5.00)
            {
                return CoinType.Nickel;
            }
            return CoinType.Unacceptable;
        }
    }
}
