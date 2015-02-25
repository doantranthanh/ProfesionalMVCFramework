using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Concrete;
using ConfigViewer.Domain.Entities;
using ConfigViewer.Test.FakeData;
using NUnit.Framework;
using Rhino.Mocks;

namespace ConfigViewer.Test.ConfigReader
{
    [TestFixture]
    public class XmlConfigReader_Tests
    {
        private XDocument _xDoc;
        private XmlConfigEngine _xmlReader;
        private XlnConfigCommon _xlnConfigCommon;
        private XlnConfiguration _xlnConfiguration;
        private XmlPath _xmlPath;
        private IPathProvider _pathProvider;

        [SetUp()]
        public void SetUp()
        {
            _pathProvider = MockRepository.GenerateMock<IPathProvider>();
            _xmlPath = FakeXmlPath.CrateXmlPaths();
            _xlnConfigCommon = FakePublicWebsiteXml.CreateCommonSection();
            _xlnConfiguration = FakeConfigurationXml.CreateXlnConfiguration();

        }

        [Test()]
        [TestCase("common","ProductionMode", "false")]
        [TestCase("common", "WcfUrl", "localhost")]
        [TestCase("common", "WcfUserName", "thanh")]
        [TestCase("common", "WcfPassword", "123")]
        public void Should_Get_Correct_Value_From_Section_With_Key(string section, string key, string value)
        {
            // Arrange
            _xDoc = GetFakeXmlFile();
            _pathProvider.Stub(m => m.MapPath(Arg<string>.Is.Anything)).Return(_xmlPath.PublicWebSiteConfig);

            _xmlReader = MockRepository.GenerateStub<XmlConfigEngine>(_pathProvider);
            _xmlReader.Stub(m => m.GetXmlFile(Arg<string>.Is.Anything)).Return(_xDoc);

            // Act
            var result = _xmlReader.GetConfigValue(_xDoc, section, key);

            // Assert
            Assert.AreEqual(result, value);
        }

        [Test()]
        [TestCase(typeof(XlnConfigCommon), "common")]
        public void Should_Load_Config_File_And_Set_Propeties_For_Common(Type configType, string section)
        {
            // Arrange   
            _xDoc = GetFakeXmlFile();
            _xlnConfigCommon = MockRepository.GenerateMock<XlnConfigCommon>();
            _pathProvider.Stub(m => m.MapPath(Arg<string>.Is.Anything)).Return(_xmlPath.PublicWebSiteConfig);

            _xmlReader = MockRepository.GenerateMock<XmlConfigEngine>(_pathProvider);
            _xmlReader.Stub(m => m.GetXmlFile(Arg<string>.Is.Anything)).Return(_xDoc);
            // Act
            _xmlReader.LoadConfigs<XlnConfigCommon>(configType, _xmlPath.PublicWebSiteConfig, section, _xlnConfigCommon);

            // Assert
            Assert.AreEqual(_xlnConfigCommon.ProductionMode,false);
            Assert.AreEqual(_xlnConfigCommon.WcfUrl, "localhost");
            Assert.AreEqual(_xlnConfigCommon.WcfUserName, "thanh");
            Assert.AreEqual(_xlnConfigCommon.CompanyName, "XLN Telecom Ltd.");
            Assert.AreEqual(_xlnConfigCommon.BuildingName, "1st floor");
            Assert.AreEqual(_xlnConfigCommon.StreetName, "Millbank");
            Assert.AreEqual(_xlnConfigCommon.City, "London");
            Assert.AreEqual(_xlnConfigCommon.PostalCode, "SW1P 4QP");           
        }

        [Test()]
        [TestCase(typeof(XlnConfigCommon), "configs","common", "PostalCode","SW11 2SE")]      
        public void Should_Update_Element_Gratefully_Common_Section<T>(T configType,string rootElement, string section, string element, string updatedValue)
        {
            // Arrange         
            _xDoc = GetFakeXmlFile();
            _xlnConfigCommon.PostalCode = updatedValue;

            _pathProvider.Stub(m => m.MapPath(Arg<string>.Is.Anything)).Return(_xmlPath.PublicWebSiteConfig);

            _xmlReader = MockRepository.GenerateMock<XmlConfigEngine>(_pathProvider);

            _xmlReader.Stub(m => m.GetXmlFile(Arg<string>.Is.Anything)).Return(_xDoc);
            // Act
            _xmlReader.UpdateXmlElement(_xlnConfigCommon, _xmlPath.PublicWebSiteConfig, rootElement, section, _xlnConfigCommon);
            var result = _xDoc.Descendants(section).Single();

            // Assert
            Assert.AreEqual(result.Element(element).Value, updatedValue);

        }

        [Test()]
        [TestCase(typeof(XlnConfiguration), "PublicWebsite", "MaintenanceMode", "MaintenanceMode", true)]
        public void Should_Update_Element_Gratefully_Configuration_File<T>(T configType, string rootElement, string section,
            string element, bool updatedValue)
        {
            // Arrange         
            _xDoc = GetFakeXmlConfiguration();
            _xlnConfiguration.MaintenanceMode = updatedValue;

            _pathProvider.Stub(m => m.MapPath(Arg<string>.Is.Anything)).Return(_xmlPath.PublicWebSiteConfig);

            _xmlReader = MockRepository.GenerateMock<XmlConfigEngine>(_pathProvider);

            _xmlReader.Stub(m => m.GetXmlFile(Arg<string>.Is.Anything)).Return(_xDoc);
            // Act
            _xmlReader.UpdateXmlElement(_xlnConfiguration, _xmlPath.PublicWebSiteConfig, rootElement, section, _xlnConfiguration);
            var result = _xDoc.Descendants(rootElement).Single();

            // Assert
            Assert.AreEqual(result.Element(element).Value, updatedValue.ToString()); 
        }
         

        [Test()]
        public void Should_Return_List_Of_First_Child_Nodes()
        {
            // Arrange

            _pathProvider.Stub(m => m.MapPath(Arg<string>.Is.Anything)).Return(_xmlPath.PublicWebSiteConfig);

            _xmlReader = MockRepository.GenerateMock<XmlConfigEngine>(_pathProvider);
            _xmlReader.Stub(m => m.GetXmlFile(Arg<string>.Is.Anything)).Return(_xDoc);
            // Act
            var list = _xmlReader.GetAllFirstChildElements(_xmlPath.PublicWebSiteConfig, "configs");
            // Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(list.ToArray()[0], "common");
            Assert.AreEqual(list.ToArray()[1], "xlntelecom");
        }


        private static XDocument GetFakeXmlFile()
        {
            return FakePublicWebsiteXml.GetFakePublicWebsite();
        }

        private static XDocument GetFakeXmlConfiguration()
        {
            return FakeConfigurationXml.GetFakeWebsiteConfiguration();
        }
    }
}
