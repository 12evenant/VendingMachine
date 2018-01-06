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
        private readonly decimal _price;

        public ProductBase(int stock, decimal price)
        {
            _stock = stock;
            _price = price;
        }

        public void RemoveStock()
        {
            _stock--;
        }

        public decimal GetPrice()
        {
            return _price;
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
