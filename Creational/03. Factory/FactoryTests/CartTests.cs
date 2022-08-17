using AbstractFactory;
using AbstractFactory.Models.Commerce.AbstractFactory;
using AbstractFactory.Models.Commerce.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactoryTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FinalizeOrderWithoutPurchaseProvider_ThrowsException()
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var cart = new Cart(order, null);

            var label = cart.Finalize();
        }

        [TestMethod]
        public void FinalizeOrderWithSwedenPurchaseProvider_GeneratesShippingLabel()
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var purchaseProviderFactory = new SwedenPurchaseProviderFactory();

            var cart = new Cart(order, purchaseProviderFactory);

            var label = cart.Finalize();

            Assert.IsNotNull(label);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FinalizeAlreadyFinalizedOrder_ThrowsInvalidOperationException()
        {
            var cart = CreateShoppingCart();

            cart.Finalize();

            var label = cart.Finalize();

            Assert.IsNotNull(label);
        }

        private Cart CreateShoppingCart(IPurchaseProviderFactory purchaseProviderFactory = null)
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var provider = purchaseProviderFactory ?? new SwedenPurchaseProviderFactory();

            var cart = new Cart(order, provider);

            return cart;

        }
    }
}
