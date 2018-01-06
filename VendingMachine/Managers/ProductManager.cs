using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;
using VendingMachine.Products;

namespace VendingMachine.Managers
{
    public class ProductManager
    {
        protected Cola cola;
        protected Chips chips;
        protected Candy candy;
        protected SelectedProduct SelectedProduct;
        public ProductManager()
        {
            cola = new Cola();
            chips = new Chips();
            candy = new Candy();
        }

        public SelectedProduct GetSelectedProductDetails(ProductType productType)
        {
            SelectedProduct
        }


    }
}
