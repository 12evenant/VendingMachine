using System;
using System.Globalization;
using VendingMachine.Enums;
using VendingMachine.Products;


namespace VendingMachine.Managers
{
    public class Machine
    {
        protected CoinManager coinManager;
        protected ProductManager productManager;

        public decimal CurrentValue;
        public string CurrentDisplay;

        private bool _productRecentlyDispensed;
        private bool _priceShown;
        private bool _showCurrentPriceNext;

        public Machine()
        {
            coinManager = new CoinManager();
            productManager = new ProductManager();

            CurrentValue = DefaultValueConstants.DEFAULT_VALUE;
            CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;

            _productRecentlyDispensed = false;
            _priceShown = false;
            _showCurrentPriceNext = false;
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
                    UpdateValuesWhenProductIsDispensed();
                }
            }
            else
            {
                ManageSubSequentDisplays(productManager.cola.Price);
            }
            
        }

        public void ChipsSelected()
        {
            if (productManager.chips.Price <= CurrentValue)
            {
                bool chipsDispensed = productManager.chips.Dispense();

                if (chipsDispensed)
                {
                    UpdateValuesWhenProductIsDispensed();
                }
            }
            else
            {
                ManageSubSequentDisplays(productManager.chips.Price);
            }
        }

        public void CandySelected()
        {
            if (productManager.candy.Price <= CurrentValue)
            {
                bool candyDispensed = productManager.candy.Dispense();

                if (candyDispensed)
                {
                    UpdateValuesWhenProductIsDispensed();
                }
            }
            else
            {
                ManageSubSequentDisplays(productManager.candy.Price);
            }
        }

        private void ManageSubSequentDisplays(decimal price)
        {
            if (!_priceShown)
            {
                UpdateDisplayToPrice(price);
            }
            else if (!_showCurrentPriceNext)
            {
                CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;

                _showCurrentPriceNext = true;
            }
            else
            {
                CurrentDisplay = CurrentValue.ToString(CultureInfo.InvariantCulture);

                _showCurrentPriceNext = false;
            }
        }

        public void CheckDisplay()
        {
            if (_productRecentlyDispensed)
            {
                CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;

                CurrentValue = DefaultValueConstants.DEFAULT_VALUE;

                _productRecentlyDispensed = false;
            }
            else
            {
                ManageSubSequentDisplays(productManager.chips.Price);
            }
        }

        private void UpdateDisplayToPrice(decimal price)
        {
            CurrentDisplay = DisplayStringConstants.PRICE_DISPLAY_PREFIX + price;
           
            _priceShown = true;
        }

        private void UpdateValuesWhenProductIsDispensed()
        {
            _productRecentlyDispensed = true;

            _priceShown = false;

            CurrentDisplay = DisplayStringConstants.THANK_YOU_DISPLAY;
        }
    }
}
