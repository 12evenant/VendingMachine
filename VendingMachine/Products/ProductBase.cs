using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public class ProductBase : IProduct
    {
        private int _stock;

        public ProductBase(int stock)
        {
            _stock = stock;
        }

        public void RemoveStock()
        {
            _stock--;
        }

        public int GetStock()
        {
            return _stock;
        }

        public bool Dispense()
        {
            return true;
        }
    }
}
