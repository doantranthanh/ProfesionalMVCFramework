using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.WebUI.Controllers;
using NUnit.Framework;
using SportsStore.Domain.Abastract;
using SportsStore.Domain.Entities;
using Rhino.Mocks;
namespace SportsStore.WebUI.Controllers.Tests
{
    [TestFixture()]
    public class NavControllerTests
    {
        private IProductRepository _repository;
        private NavController _navController;
        private Product[] _products;

        [SetUp()]
        public void SetUp()
        {
            _repository = MockRepository.GenerateStub<IProductRepository>();
            _products = new Product[] {
                new Product {ProductID = 1, Name = "P1", Category="Apples"},
                new Product {ProductID = 2, Name = "P2", Category="Apples"},
                new Product {ProductID = 3, Name = "P3", Category="Plums"},
                new Product {ProductID = 4, Name = "P4", Category="Oranges"}
            };
        }

        [Test()]
        public void Can_Create_Categories()
        {
            // Arrange
            _repository.Stub(m => m.Products).Return(_products.AsQueryable());
            _navController = new NavController(_repository);

            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)_navController.Menu().Model).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }
    }
}
