using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFarmersMarket.Operations.Contracts
{
    internal interface IProductCart
    {
        void AddProductToCart(string productCode);
        void DisplayProduct();
    }
}
