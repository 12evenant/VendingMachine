using System;
using System.Globalization;


namespace VendingMachine.Managers
{
    public class Machine
    {
        protected CoinManager coinManager;
        protected ProductManager productManager;

        public decimal CurrentValue;
        public string CurrentDisplay;
        private bool _productRecentlyDispensed;

        public Machine()
        {
            coinManager = new CoinManager();
            productManager = new ProductManager();

            CurrentValue = DefaultValueConstants.DEFAULT_VALUE;
            CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;
            _productRecentlyDispensed = false;
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
                        CurrentValue = CurrentValue + DimeConstants.DIME_VALUE;
                        return true;
                    case CoinType.Nickel:
                        CurrentValue = CurrentValue + NickelConstants.NICKEL_VALUE;
                        return true;
                    case CoinType.Quarter:
                        CurrentValue = CurrentValue + QuarterConstants.QUARTER_VALUE;
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
                CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;
                CurrentValue = DefaultValueConstants.DEFAULT_VALUE;
            }
        }

        public void CheckIfChangeIsAvailable()
        {
            bool changeAvailable = coinManager.CheckIfChangeIsAvailable(CurrentValue);

            if (!changeAvailable)
                CurrentDisplay = DisplayStringConstants.EXACT_CHANGE_ONLY_DISPLAY;

        }

        public void ColaSelected()
        {
            if (productManager.cola.Price <= CurrentValue)
            {
                bool colaDispensed = productManager.cola.Dispense();

                if (colaDispensed)
                {
                    _productRecentlyDispensed = true;

                    CurrentDisplay = DisplayStringConstants.THANK_YOU_DISPLAY;
                }

            }
        }

        public void ChipsSelected()
        {
            if (productManager.chips.Price <= CurrentValue)
            {
                bool chipsDispensed = productManager.chips.Dispense();

                if (chipsDispensed)
                {
                    _productRecentlyDispensed = true;

                    CurrentDisplay = DisplayStringConstants.THANK_YOU_DISPLAY;
                }
            }
        }

        public void CandySelected()
        {
            if (productManager.candy.Price <= CurrentValue)
            {
                bool candyDispensed = productManager.candy.Dispense();

                if (candyDispensed)
                {
                    _productRecentlyDispensed = true;

                    CurrentDisplay = DisplayStringConstants.THANK_YOU_DISPLAY;
                }
            }
        }

        public void CheckDisplay()
        {
            if (_productRecentlyDispensed)
            {
                CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;

                _productRecentlyDispensed = false;
            }
        }
    }
}
