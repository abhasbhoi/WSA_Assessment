// See https://aka.ms/new-console-template for more information
using TheFarmersMarket;
using TheFarmersMarket.Operations.Contracts;

IProductCart productCart = new ProductCart();
productCart.AddProductToCart("CH1");
productCart.AddProductToCart("AP1");
productCart.AddProductToCart("AP1");
productCart.AddProductToCart("AP1");
productCart.AddProductToCart("MK1");

var checkoutCart = productCart.CheckOut();
productCart.DisplayCheckoutCart();
