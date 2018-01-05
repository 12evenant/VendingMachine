using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;

namespace VendingMachineTests.Helper
{
    internal class ProductSelector : IEnumerable<object[]>
    {
        private readonly List<object[]> _productTypes = new List<object[]>
        {
            new object[] { ProductType.Cola },
            new object[] { ProductType.Candy},
            new object[] { ProductType.Chips}
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _productTypes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
