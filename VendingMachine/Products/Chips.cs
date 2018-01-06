using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public class Chips : ProductBase
    {
        private static int _stock = 2;
        private static readonly decimal _price = (decimal) 0.50;

        public Chips() : base(_stock, _price)
        {
            
        }
    }
}
