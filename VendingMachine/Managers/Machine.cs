using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Managers
{
    public class Machine
    {
        protected CoinManager coinManager;

        public decimal CurrentValue;

        public Machine()
        {
            coinManager = new CoinManager();
            CurrentValue = (decimal) 0.0;
        }

        public void InsertCoin(double weight, double diameter)
        {
            CoinType coinType = coinManager.Identify(weight, diameter);

            AddOrIgnoreCoinToValue(coinType);
        }

        private void AddOrIgnoreCoinToValue(CoinType coinType)
        {
            if (coinType != CoinType.Unacceptable)
            {
                switch (coinType)
                {
                    case CoinType.Dime:
                        CurrentValue = CurrentValue + (decimal)0.10;
                        break;
                }
            }
        }
    }
}
