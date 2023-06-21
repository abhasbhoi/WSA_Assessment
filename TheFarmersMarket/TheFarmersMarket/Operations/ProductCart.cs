using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFarmersMarket.Models;
using TheFarmersMarket.Operations.Contracts;

namespace TheFarmersMarket
{
    internal class ProductCart : IProductCart
    {
        private IPricingEngine _pricingEngine;
        private List<Product> _products;
        private List<Offer> _offers;
        private List<ProductOffer> _cart;

        public ProductCart()
        {
            _pricingEngine = new PricingEngine();
            _cart = new List<ProductOffer>();

            InitializeProducts();
            InitializeOffers();
        }
       
        private void InitializeProducts()
        {
            _products = new List<Product>();
            _products.Add(new Product { ProductCode = ProductCode.CH1, Name = ProductName.Chai, Price = 3.11M });
            _products.Add(new Product { ProductCode = ProductCode.AP1, Name = ProductName.Apples, Price = 6.00M });
            _products.Add(new Product { ProductCode = ProductCode.CF1, Name = ProductName.Coffee, Price = 11.23M });
            _products.Add(new Product { ProductCode = ProductCode.MK1, Name = ProductName.Milk, Price = 4.75M });
            _products.Add(new Product { ProductCode = ProductCode.OM1, Name = ProductName.Oatmilk, Price = 3.69M });
        }

        private void InitializeOffers()
        {
            _offers = new List<Offer>();
            _offers.Add(new Offer { OfferCode = OfferCode.BOGO, OfferDescription = "Buy-One-Get-One-Free Special on Coffee. (Unlimited)" });
            _offers.Add(new Offer { OfferCode = OfferCode.APPL, OfferDescription = "If you buy 3 or more bags of Apples, the price drops to $4.50." });
            _offers.Add(new Offer { OfferCode = OfferCode.CHMK, OfferDescription = "Purchase a box of Chai and get milk free. (Limit 1)" });
            _offers.Add(new Offer { OfferCode = OfferCode.APOM, OfferDescription = "Purchase a bag of Oatmeal and get 50% off a bag of Apples" });
        }

        public void AddProductToCart(string productCode)
        {
            if (productCode != null && _products.Any(x => x.ProductCode.ToString() == productCode))
            {
                var product = _products.First(x => x.ProductCode.ToString() == productCode);
                _cart.Add(new ProductOffer { ProductCode = product.ProductCode, Price = product.Price});
            }
                
            else
                throw new Exception("Invalid Product");
        }

        public void DisplayProduct()
        {
            var finalCart = _pricingEngine.ApplyOffer(_cart);

            foreach(var item in finalCart)
            {
                Console.Write($"{item.ProductCode}    {item.OfferCode}    {item.Price}");
                Console.WriteLine();
            }
            Console.WriteLine($"Total        {finalCart.Sum(x => x.Price)}");
        }
    }
}
