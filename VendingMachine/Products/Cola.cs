using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public class Cola : ProductBase
    {
        public decimal Price => (decimal) 1.00;
    }
}
