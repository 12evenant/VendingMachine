using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTests
{
    public class TestBase
    {
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
    }
}
