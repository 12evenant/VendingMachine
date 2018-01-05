using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Managers
{
    public class Machine
    {
        private const string DEFAULT_DISPLAY = "INSERT COIN";

        protected CoinManager coinManager;

        public decimal CurrentValue;
        public string CurrentDisplay;
        public Machine()
        {
            coinManager = new CoinManager();
            CurrentValue = (decimal) 0.0;
            CurrentDisplay = DEFAULT_DISPLAY;
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
                        CurrentValue = CurrentValue + coinManager.DimeValue;
                        break;
                    case CoinType.Nickel:
                        CurrentValue = CurrentValue + coinManager.NickelValue;
                        break;
                    case CoinType.Quarter:
                        CurrentValue = CurrentValue + coinManager.QuarterValue;
                        break;
                }
            }
        }
    }
}
