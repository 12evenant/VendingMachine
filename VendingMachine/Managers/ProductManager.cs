using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Products;

namespace VendingMachine.Managers
{
    public class ProductManager
    {
        public Cola cola;
        public Chips chips;
        public Candy candy;

        public ProductManager()
        {
            cola = new Cola();
            chips = new Chips();
            candy = new Candy();
        }
    }
}
