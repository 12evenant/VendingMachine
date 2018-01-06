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

        public bool CheckIfChangeIsAvailable(decimal colaValue, decimal chipsValue, decimal candyValue)
        {
            bool changeForColaAvailable = CheckIfChangeForProductIsAvailable(colaValue);
            bool changeForChipsAvailable = CheckIfChangeForProductIsAvailable(chipsValue);
            bool changeForCandyAvailable = CheckIfChangeForProductIsAvailable(candyValue);

            return (changeForCandyAvailable && changeForChipsAvailable && changeForColaAvailable);
        }

        private bool CheckIfChangeForProductIsAvailable(decimal value)
        {
            int numberOfQuarters = GetNumberOfQuarters();
            while (value > QuarterConstants.QUARTER_VALUE && numberOfQuarters > 0)
            {
                numberOfQuarters--;
                value -= QuarterConstants.QUARTER_VALUE;
            }

            int numberOfDimes = GetNumberOfDimes();
            while (value > DimeConstants.DIME_VALUE && numberOfDimes > 0)
            {
                numberOfDimes--;
                value -= DimeConstants.DIME_VALUE;
            }

            int numberOfNickels = GetNumberOfNickels();
            while (value > NickelConstants.NICKEL_VALUE && numberOfNickels > 0)
            {
                numberOfNickels--;
                value -= NickelConstants.NICKEL_VALUE;
            }

            if (value > 0)
            {
                return false;
            }
            return true;
        }

        private int GetNumberOfQuarters()
        {
            List<CoinType> quarters = CoinBank.Where(c => c == CoinType.Quarter).ToList();

            return quarters.Count;
        }

        private int GetNumberOfDimes()
        {
            List<CoinType> dimes = CoinBank.Where(c => c == CoinType.Dime).ToList();

            return dimes.Count;
        }

        private int GetNumberOfNickels()
        {
            List<CoinType> nickels = CoinBank.Where(c => c == CoinType.Nickel).ToList();

            return nickels.Count;
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
            int quarterCount = GetNumberOfQuarters();

            return quarterCount*QuarterConstants.QUARTER_VALUE;
        }

        private decimal GetValueOfDimesInBank()
        {
            int dimeCount = GetNumberOfDimes();

            return dimeCount*DimeConstants.DIME_VALUE;
        }

        private decimal GetValueOfNickels()
        {
            int nickelCount = GetNumberOfNickels();

            return nickelCount*NickelConstants.NICKEL_VALUE;
        }
    }
}
