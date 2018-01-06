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

                            ManageDisplay(selectedProduct.Price);
                        }
                    }
                }
                else
                {
                    UpdateStateToSoldOut();
                }
            }
        }

        private void UpdateStateToSoldOut()
        {
            CurrentDisplay = DisplayStringConstants.SOLD_OUT_DISPLAY;

            _soldOutShown = true;
        }

        private void ManageSubSequentDisplays(decimal price)
        {
             if (!_showCurrentPriceNext)
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

        private void ManageDisplay(decimal price)
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
                
        //    }
        //}

        private void UpdateDisplayToPrice(decimal price)
        {
            CurrentDisplay = DisplayStringConstants.PRICE_DISPLAY_PREFIX + price;
           
            _priceShown = true;
        }

        private void UpdateValuesWhenProductIsDispensed()
        {
            _productRecentlyDispensed = true;

            _priceShown = false;

            CurrentValue = 0;

            CurrentDisplay = DisplayStringConstants.THANK_YOU_DISPLAY;
        }
    }
}
