using System;
using System.Collections;
using System.Collections.Generic;
using VendingMachine;

namespace VendingMachineTests.Helper
{
    internal class CoinGenerator : TestBase, IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {CoinType.Nickel, nickelWeight, nickelDiameter,nickelValue, true},
            new object[] {CoinType.Dime, dimeWeight, dimeDiameter, dimeValue,true},
            new object[] {CoinType.Quarter, quarterWeight, quarterDiameter,quarterValue, true},
            new object[] { CoinType.Unacceptable, pennyWeight, pennyDiameter, pennyValue,false}
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
