﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public class ProductBase : IProduct
    {
        public bool Dispense()
        {
            return true;
        }
    }
}
