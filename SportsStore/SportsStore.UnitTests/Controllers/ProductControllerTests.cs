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
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers.Tests
{
    [TestFixture()]
    public class ProductControllerTests
    {
        private IProductRepository _repository;
        private ProductController _controller;
        private Product[] _products;

        [SetUp()]
        public void SetUp()
        {
            _repository = MockRepository.GenerateStub<IProductRepository>();
            _products = new Product[] {
                new Product {ProductID = 1, Name = "P1", Category="Cat1"},
                new Product {ProductID = 2, Name = "P2", Category="Cat2"},
                new Product {ProductID = 3, Name = "P3", Category="Cat1"},
                new Product {ProductID = 4, Name = "P4", Category="Cat2"},
                new Product {ProductID = 5, Name = "P5", Category="Cat3"}
            };
        }

        [Test()]
        public void Can_Paginate()
        {
            // Arrange
            _repository.Stub(m => m.Products).Return(_products.AsQueryable());
            _controller = new ProductController(_repository);
            _controller.PageSize = 3;

            var viewResult = _controller.List("Cat2",1) as ViewResult;
            // Act
            ProductsListViewModel result = (ProductsListViewModel) viewResult.Model;

            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.AreEqual(prodArray.Length,2);
            Assert.AreEqual(prodArray[0].Name, "P2");
            Assert.AreEqual(prodArray[1].Name, "P4");

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 1);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);

            Assert.AreEqual(prodArray[0].Category, "Cat2");
            Assert.AreEqual(prodArray[1].Category, "Cat2");
        }
    }
}
