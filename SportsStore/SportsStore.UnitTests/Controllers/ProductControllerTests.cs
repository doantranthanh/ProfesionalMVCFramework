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
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            };
        }

        [Test()]
        public void Can_Paginate()
        {
            // Arrange
            _repository.Stub(m => m.Products).Return(_products.AsQueryable());
            _controller = new ProductController(_repository);
            _controller.PageSize = 3;

            var viewResult = _controller.List(2) as ViewResult;
            // Act
            ProductsListViewModel result = (ProductsListViewModel) viewResult.Model;

            // Assert
            IEnumerable<Product> prodArray = result.Products;
            Assert.IsTrue(prodArray.Count() == 2);
            Assert.AreEqual(prodArray.ElementAt(0).Name, "P4");
            Assert.AreEqual(prodArray.ElementAt(1).Name, "P5");

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
