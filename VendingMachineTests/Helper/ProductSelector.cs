using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;

namespace VendingMachineTests.Helper
{
    internal class ProductSelector : TestBase, IEnumerable<object[]>
    {
        private readonly List<object[]> _productTypes = new List<object[]>
        {
            new object[] { ProductType.Cola , colaValue},
            new object[] { ProductType.Candy, candyValue},
            new object[] { ProductType.Chips, chipsValue}
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
