using TheFarmersMarket.Operations.Contracts;

namespace TheFarmersMarket.Test
{
    [TestClass]
    public class ProductCartTest
    {
        private IProductCart _productCart;
        public ProductCartTest()
        {
            _productCart = new ProductCart();
        }
        [TestMethod]
        public void ProductCart_ValidInput()
        {
            _productCart.AddProductToCart("CH1");
            _productCart.AddProductToCart("AP1");
            _productCart.AddProductToCart("AP1");
            _productCart.AddProductToCart("AP1");
            _productCart.AddProductToCart("MK1");

            var currrentCart = _productCart.GetCurrentCart();

            var checkoutCart = _productCart.CheckOut();

            Assert.IsNotNull(currrentCart);
            Assert.AreEqual(5, currrentCart.Count);

            Assert.IsNotNull(checkoutCart);
            Assert.AreEqual(16.61M, checkoutCart.Sum(x => x.Price));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),"Invalid Product")]
        public void AddProductToCart_InValidInput()
        {
            _productCart.AddProductToCart("XYZ");
        }
    }
}