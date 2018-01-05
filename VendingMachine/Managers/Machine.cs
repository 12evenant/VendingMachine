using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Products;

namespace VendingMachine.Managers
{
    public class Machine
    {
        private const string DEFAULT_DISPLAY = "INSERT COIN";
        private const decimal DEFAULT_VALUE = (decimal) 0.0;
        private const string EXACT_CHANGE_ONLY_DISPLAY = "EXACT CHANGE ONLY";
        private const string THANK_YOU_DISPLAY = "THANK YOU";

        protected CoinManager coinManager;
        protected ProductManager productManager;

        public Cola cola;
        public Chips chips;

        public decimal CurrentValue;
        public string CurrentDisplay;
        public bool ColaDispensing;

        public Machine()
        {
            coinManager = new CoinManager();
            productManager = new ProductManager();

            cola = new Cola();
            chips = new Chips();

            CurrentValue = DEFAULT_VALUE;
            CurrentDisplay = DEFAULT_DISPLAY;
            ColaDispensing = false;
        }

        public void InsertCoin(double weight, double diameter)
        {
            CoinType coinType = coinManager.Identify(weight, diameter);

            bool coinAdded = AddOrIgnoreCoinToValue(coinType);

            if (coinAdded)
                CurrentDisplay = CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        private bool AddOrIgnoreCoinToValue(CoinType coinType)
        {
            if (coinType != CoinType.Unacceptable)
            {
                switch (coinType)
                {
                    case CoinType.Dime:
                        CurrentValue = CurrentValue + coinManager.DimeValue;
                        return true;
                    case CoinType.Nickel:
                        CurrentValue = CurrentValue + coinManager.NickelValue;
                        return true;
                    case CoinType.Quarter:
                        CurrentValue = CurrentValue + coinManager.QuarterValue;
                        return true;
                }
            }
            return false;
        }

        public void ReturnButtonPressed()
        {
            bool coinReturned = coinManager.ReturnCoins(CurrentValue);

            if (coinReturned)
            {
                CurrentDisplay = DEFAULT_DISPLAY;
                CurrentValue = DEFAULT_VALUE;
            }
        }

        public void CheckIfChangeIsAvailable()
        {
            bool changeAvailable = coinManager.CheckIfChangeIsAvailable(CurrentValue);

            if (!changeAvailable)
                CurrentDisplay = EXACT_CHANGE_ONLY_DISPLAY;

        }

        public void ColaSelected()
        {
            if (cola.Price <= CurrentValue)
            {
                bool colaDispensed = cola.Dispense();

                if (colaDispensed)
                    CurrentDisplay = THANK_YOU_DISPLAY;
            }
        }

        public void ChipsSelected()
        {
            if (chips.Price <= CurrentValue)
            {
                bool chipsDispensed = chips.Dispense();

                if (chipsDispensed)
                    CurrentDisplay = THANK_YOU_DISPLAY;
            }
        }
    }
}
