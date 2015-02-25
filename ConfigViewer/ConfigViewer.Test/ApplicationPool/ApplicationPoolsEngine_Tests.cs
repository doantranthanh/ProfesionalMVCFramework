using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Concrete;
using NUnit.Framework;
using Rhino.Mocks;

namespace ConfigViewer.Test.ApplicationPool
{
    [TestFixture]
    public class ApplicationPoolsEngine_Tests
    {
        private ApplicationPoolsEngine _applicationPoolsEngine;

        [SetUp()]
        public void SetUp()
        {
            _applicationPoolsEngine = MockRepository.GenerateMock<ApplicationPoolsEngine>();
            _applicationPoolsEngine.IISApplicationPath = "IIS://LocalHost/w3svc";
        }

        [Test()]
        public void Should_Return_List_Of_Application_Pools_From_IIS()
        {
            // Arrange

            // Act
            var result = _applicationPoolsEngine.GetListAppPools();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        //[Test()]
        //[TestCase("xln.xln")]
        //public void Should_Recycle_Gracefully_Application_Pools(string appPoolName)
        //{
        //    // Arrange

        //    // Act
        //    _applicationPoolsEngine.RecyleApplicationPool(appPoolName);

        //    // Assert
            
        //}
    }
}
