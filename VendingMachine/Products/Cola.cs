using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public class Cola : ProductBase
    {
        private int Stock = 10;
        public decimal Price => (decimal) 1.00;

        public new int GetStock()
        {
            return Stock;
        }
    }
}
