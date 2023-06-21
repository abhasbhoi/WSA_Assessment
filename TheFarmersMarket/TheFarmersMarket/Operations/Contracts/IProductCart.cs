using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFarmersMarket.Models;

namespace TheFarmersMarket.Operations.Contracts
{
    public interface IProductCart
    {
        void AddProductToCart(string productCode);
        List<ProductOffer> GetCurrentCart();
        List<ProductOffer> CheckOut();
        void DisplayCheckoutCart();
    }
}
