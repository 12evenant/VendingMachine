using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public class Candy : ProductBase
    {
        public decimal Price => (decimal) 0.65;
    }
}
