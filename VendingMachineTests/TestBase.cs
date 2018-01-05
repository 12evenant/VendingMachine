using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace VendingMachineTests
{
    public class TestBase
    {
        #region Machine Constants

        public const string EXACT_CHANGE_ONLY_DISPLAY = "EXACT CHANGE ONLY";
        public const string DEFAULT_DISPLAY = "INSERT COIN";
        public const string THANK_YOU_DISPLAY = "THANK YOU";
        public const string PRICE_DISPLAY_PREFIX = "PRICE : ";
        public const decimal DEFAULT_VALUE = (decimal) 0.0;

        #endregion
        #region Nickel Constants

        public const double nickelWeight = 5.00;
        public const double nickelDiameter = 21.21;
        public const decimal nickelValue = (decimal)0.05;

        #endregion

        #region Dime Constants

        public const double dimeWeight = 2.268;
        public const double dimeDiameter = 17.9;
        public const decimal dimeValue = (decimal) 0.10;
        #endregion

        #region Quarter Constants

        public const double quarterWeight = 5.670;
        public const double quarterDiameter = 24.26;
        public const decimal quarterValue = (decimal) 0.25;

        #endregion

        #region Penny Constants

        public const double pennyWeight = 3.11;
        public const double pennyDiameter = 19.05;
        public const decimal pennyValue = (decimal) 0.01;
        #endregion

        #region Product Prices

        public const decimal colaValue = (decimal) 1.00;
        public const decimal chipsValue = (decimal) 0.50;
        public const decimal candyValue = (decimal) 0.65;

        #endregion

        public void CheckResultIsEqual(bool isValid, object valueIfTrue, object valueIfFalse, object value)
        {
            if (!isValid)
                Assert.Equal(valueIfFalse, value);
            else
                Assert.Equal(valueIfTrue, value);
        }
    }
}
