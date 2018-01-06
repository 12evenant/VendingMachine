using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public interface IProduct
    {
        decimal GetPrice();

        int GetStock();

        void RemoveStock();

        bool Dispense();
    }
}
