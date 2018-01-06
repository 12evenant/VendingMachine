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
        protected SelectedProduct selectedProduct;
        public decimal CurrentValue;
        public string CurrentDisplay;

        private bool _productRecentlyDispensed;
        private bool _priceShown;
        private bool _soldOutShown;
        private bool _showCurrentValueNext;


        public Machine()
        {
            coinManager = new CoinManager();
            productManager = new ProductManager();

            CurrentValue = DefaultValueConstants.DEFAULT_VALUE;
            CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;

            _productRecentlyDispensed = false;
            _priceShown = false;
            _showCurrentValueNext = false;
            _soldOutShown = false;
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
                        coinManager.AddCoinToBank(coinType);
                        CurrentValue = CurrentValue + DimeConstants.DIME_VALUE;
                        return true;
                    case CoinType.Nickel:
                        coinManager.AddCoinToBank(coinType);
                        CurrentValue = CurrentValue + NickelConstants.NICKEL_VALUE;
                        return true;
                    case CoinType.Quarter:
                        coinManager.AddCoinToBank(coinType);
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

        public void SelectProduct(ProductType product)
        {
            selectedProduct = productManager.GetSelectedProductDetails(product);

            if (selectedProduct != null)
            {
                if (selectedProduct.Stock > 0)
                {
                    _soldOutShown = false;

                    if (selectedProduct.Price <= CurrentValue)
                    {
                        bool productDispensed = productManager.Dispense(product);

                        if (productDispensed)
                        {
                            productManager.RemoveStock(product);

                            UpdateValuesWhenProductIsDispensed();

                        }
                    }
                    else
                    {
                        UpdateDisplayToPrice();
                    }
                }
                else
                {
                    UpdateStateToSoldOut();
                }
            }
        }
        private void UpdateDisplayToPrice()
        {
            CurrentDisplay = DisplayStringConstants.PRICE_DISPLAY_PREFIX + selectedProduct.Price;

            _priceShown = true;
        }

        private void UpdateStateToSoldOut()
        {
            CurrentDisplay = DisplayStringConstants.SOLD_OUT_DISPLAY;

            _soldOutShown = true;
        }

        public void CheckDisplay()
        {
            if (_soldOutShown)
            {
                SoldOutState();
            }
            else if (_priceShown)
            {
                if (_showCurrentValueNext)
                {
                    CurrentDisplay = CurrentValue.ToString(CultureInfo.InvariantCulture);

                    _showCurrentValueNext = false;
                }
                else
                {
                    CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;

                    _showCurrentValueNext = true;
                }
            }
            else if (_productRecentlyDispensed)
            {
                ResetDispenser();
            }
            else
            {
                CurrentDisplay = CurrentValue.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void SoldOutState()
        {
            CurrentDisplay = CurrentValue > DefaultValueConstants.DEFAULT_VALUE
                    ? CurrentValue.ToString(CultureInfo.InvariantCulture)
                    : DisplayStringConstants.DEFAULT_DISPLAY;
        }

        private void ResetDispenser()
        {
            CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;

            CurrentValue = DefaultValueConstants.DEFAULT_VALUE;

            _productRecentlyDispensed = false;
        }


        //public void CheckDisplay()
        //{
        //    if (_soldOutShown && CurrentValue == 0)
        //    {
        //        CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;
        //    }
        //    else if (_soldOutShown && CurrentValue > 0)
        //    {
        //        CurrentDisplay = CurrentValue.ToString();
        //    }
        //    else if (_productRecentlyDispensed)
        //    {
        //        CurrentDisplay = DisplayStringConstants.DEFAULT_DISPLAY;

        //        CurrentValue = DefaultValueConstants.DEFAULT_VALUE;

        //        _productRecentlyDispensed = false;
        //    }
        //    else
        //    {
        //        ManageDisplay(selectedProduct.Price);
        //    }
        //}

        private void UpdateValuesWhenProductIsDispensed()
        {
            _productRecentlyDispensed = true;

            _priceShown = false;

            CurrentValue = 0;

            CurrentDisplay = DisplayStringConstants.THANK_YOU_DISPLAY;
        }
    }
}
