using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.WebUI.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using SportsStore.Domain.Abastract;
using SportsStore.Domain.Entities;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Controllers.Tests
{
    [TestFixture()]
    public class CartControllerTests
    {
        private IProductRepository _repository;
        private CartController _controller;
        private Product[] _products;

        [SetUp()]
        public void SetUp()
        {
            _repository = MockRepository.GenerateStub<IProductRepository>();
            _products = new Product[] {
                new Product {ProductID = 1, Name = "P1", Category="Apples"},    
            };
        }

        [Test()]
        public void Can_Add_To_Cart()
        {
            // Arrange
            _repository.Stub(x => x.Products).Return(_products.AsQueryable());
            Cart cart = new Cart();
            _controller = new CartController(_repository);

            // Act

            _controller.AddToCart(cart, 1, null);
            
            // Assert

            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }

        [Test()]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            // Arrange
            _repository.Stub(x => x.Products).Return(_products.AsQueryable());
            Cart cart = new Cart();
            _controller = new CartController(_repository);

            // Act
            RedirectToRouteResult result = _controller.AddToCart(cart, 2, "myUrl");

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        [Test()]
        public void Can_View_Cart_Contents()
        {
            // Arrange
            Cart cart = new Cart();

            _controller = new CartController(null);

            // Act - call the Index action method
            CartIndexViewModel result = (CartIndexViewModel)_controller.Index(cart, "myUrl").ViewData.Model;

            //Assert

            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
    }
}
