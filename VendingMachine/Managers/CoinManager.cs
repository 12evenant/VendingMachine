﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Managers
{
    public class CoinManager
    {
        public CoinType Identify(double weight, double diameter)
        {
            if (weight == NickelConstants.NICKEL_WEIGHT && diameter == NickelConstants.NICKEL_DIAMETER)
            {
                return CoinType.Nickel;
            }
            if (weight == DimeConstants.DIME_WEIGHT && diameter == DimeConstants.DIME_DIAMETER)
            {
                return CoinType.Dime;
            }
            if (weight == QuarterConstants.QUARTER_WEIGHT && diameter == QuarterConstants.QUARTER_DIAMETER)
            {
                return CoinType.Quarter;
            }
            return CoinType.Unacceptable;
        }

        public bool ReturnCoins(decimal currentValue)
        {
            //logic to return coins here?

            return true;
        }

        public bool CheckIfChangeIsAvailable(decimal currentValue)
        {
            //logic to check goes here

            return true;
        }

    }
}
