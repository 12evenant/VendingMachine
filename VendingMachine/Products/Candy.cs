using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public class Candy : ProductBase
    {
        private static int _stock = 2;
        public decimal Price => (decimal) 0.65;

        public Candy() : base(_stock)
        {
            
        }
    }
}
