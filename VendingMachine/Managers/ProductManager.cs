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
            SelectedProduct = new SelectedProduct();
        }

        public SelectedProduct GetSelectedProductDetails(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Cola:
                {
                    SelectedProduct.Price = cola.GetPrice();
                    SelectedProduct.Stock = cola.GetStock();
                    return SelectedProduct;
                }
                case ProductType.Chips:
                {
                    SelectedProduct.Price = chips.GetPrice();
                    SelectedProduct.Stock = chips.GetStock();
                    return SelectedProduct;
                }
                case ProductType.Candy:
                {
                    SelectedProduct.Price = candy.GetPrice();
                    SelectedProduct.Stock = candy.GetStock();
                    return SelectedProduct;
                }
                default:
                    return null;
            }
        }

        public void RemoveStock(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Cola:
                {
                    cola.RemoveStock();
                    break;
                }
                case ProductType.Chips:
                {
                    chips.RemoveStock();
                    break;
                }
                case ProductType.Candy:
                {
                    candy.RemoveStock();
                    break;
                }
            }
        }

        public bool Dispense(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Cola:
                {
                    bool colaDispensed = cola.Dispense();
                    return colaDispensed;
                }
                case ProductType.Chips:
                {
                    bool chipsDispensed = chips.Dispense();
                    return chipsDispensed;
                }
                case ProductType.Candy:
                {
                    bool candyDispensed = candy.Dispense();
                    return candyDispensed;
                }
                default:
                    return false;
            }
        }
    }
}