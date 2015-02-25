using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ConfigViewer.Controllers;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Entities;
using ConfigViewer.Test.FakeData;
using NUnit.Framework;
using Rhino.Mocks;

namespace ConfigViewer.Test.Controller
{
    [TestFixture]
    public class NavigationController_Tests
    {
        private IXmlConfigReader _configReader;
        private NavigationController _controller;
        private XlnMainSection _xlnMainSection;

        [SetUp()]
        public void SetUp()
        {
            _configReader = MockRepository.GenerateStub<IXmlConfigReader>();
            _xlnMainSection = new XlnMainSection
            {
                PublicWebsiteSections = FakePublicWebsiteXml.CreateXlnMainSection().ToList(),
                ConfigurationSections = FakeConfigurationXml.CreateSections().ToList()
            };
        }

        [Test]
        [TestCase("configs","PublicWebsites")]
        public void Should_Return_The_List_Of_Menu(string configs, string configurations)
        {
            // Arrange
            _configReader.Expect(n => n.GetAllFirstChildElements(Arg<string>.Is.Anything, Arg<string>.Is.Equal(configs))).Return(_xlnMainSection.PublicWebsiteSections).Repeat.Once();
            _configReader.Expect(n => n.GetAllFirstChildElements(Arg<string>.Is.Anything, Arg<string>.Is.Equal(configurations))).Return(_xlnMainSection.ConfigurationSections).Repeat.Once();
            _controller = MockRepository.GenerateMock<NavigationController>(_configReader);

            // Act
            var model = (XlnMainSection) _controller.Menu().Model;

            // Assert
            Assert.IsNotNull(model);
            Assert.AreSame(model.PublicWebsiteSections, _xlnMainSection.PublicWebsiteSections);
            Assert.AreSame(model.PublicWebsiteSections, _xlnMainSection.PublicWebsiteSections);
        }
    }
}
