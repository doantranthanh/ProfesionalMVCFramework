using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp;
using NUnit.Framework;
using Rhino.Mocks;

namespace ProductApp.Tests
{
    [TestFixture()]
    public class MyPriceReducerTests
    {
        [Test()]
        public void All_Prices_Are_Changed()
        {
            //arrange
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = 10;
            IEnumerable<decimal> prices = repo.GetProducts().Select(e => e.Price);
            decimal[] initialPrices = prices.ToArray();
            MyPriceReducer target = new MyPriceReducer(repo);

            //act
            target.ReducePrices(reductionAmount);
            prices.Zip(initialPrices, (p1, p2) =>
            {
                if (p1 == p2)
                {
                    Assert.Fail();
                }
                return p1;
            });
            //assert
        }

        [Test]
        public void Correct_Total_Reduction_Amount()
        {
            // Arrange
            Product[] products = new Product[] {
                new Product() { Name = "Kayak", Price = 275M},
                new Product() { Name = "Lifejacket", Price = 48.95M},
                new Product() { Name = "Soccer ball", Price = 19.50M},
                new Product() { Name = "Stadium", Price = 79500M}
            };

            IProductRepository _mockProductRepository = MockRepository.GenerateStub<IProductRepository>();
            _mockProductRepository.Stub(m => m.GetProducts()).Return(products);

            decimal reductionAmount = 10;
            decimal initialTotal = products.Sum(p => p.Price);

            MyPriceReducer target = new MyPriceReducer(_mockProductRepository);

            // Act
            target.ReducePrices(reductionAmount);

            var expected = initialTotal - (products.Count() * reductionAmount);

            // Assert
            Assert.AreEqual(products.Sum(p => p.Price), expected);

        }

        [Test]
        public void No_Price_Less_Than_One_Dollar()
        {
            // Arrange
            FakeRepository repo = new FakeRepository();
            decimal reductionAmount = decimal.MaxValue;
            MyPriceReducer target = new MyPriceReducer(repo);

            // Act
            target.ReducePrices(reductionAmount);

            // Assert
            foreach (Product product in repo.GetProducts())
            {
                Assert.IsTrue(product.Price >= 1);
            }
        }
    }
}
