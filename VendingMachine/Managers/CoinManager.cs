using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;

namespace VendingMachine.Managers
{
    public class CoinManager
    {
        private List<CoinType> CoinBank;

        public CoinManager()
        {
            CoinBank = new List<CoinType>();
        }

        public void AddCoinToBank(CoinType coin)
        {
            CoinBank.Add(coin);
        }

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

        public bool CheckIfChangeIsAvailable(decimal colaValue, decimal chipsValue, decimal candyDecimal)
        {
            throw new NotImplementedException();
        }


        public decimal GetValueOfBank()
        {
            decimal quarterValue = GetValueOfQuartersInBank();
            decimal dimeValue = GetValueOfDimesInBank();
            decimal nickelValue = GetValueOfNickels();

            return quarterValue + dimeValue + nickelValue;
        }

        private decimal GetValueOfQuartersInBank()
        {
            List<CoinType> quarters = CoinBank.Where(c => c == CoinType.Quarter).ToList();

            return quarters.Count*QuarterConstants.QUARTER_VALUE;
        }

        private decimal GetValueOfDimesInBank()
        {
            List<CoinType> dimes = CoinBank.Where(c => c == CoinType.Dime).ToList();

            return dimes.Count*DimeConstants.DIME_VALUE;
        }

        private decimal GetValueOfNickels()
        {
            List<CoinType> nickels = CoinBank.Where(c => c == CoinType.Nickel).ToList();

            return nickels.Count*NickelConstants.NICKEL_VALUE;
        }
    }
}
