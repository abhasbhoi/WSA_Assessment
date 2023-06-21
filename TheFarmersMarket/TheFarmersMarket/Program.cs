// See https://aka.ms/new-console-template for more information
using TheFarmersMarket;

ProductCart productCart = new ProductCart();
productCart.AddProductToCart("CH1");
productCart.AddProductToCart("AP1");
productCart.AddProductToCart("AP1");
productCart.AddProductToCart("AP1");
productCart.AddProductToCart("MK1");

productCart.DisplayProduct();
