using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using ConfigViewer.Controllers;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Entities;
using ConfigViewer.Test.FakeData;
using NUnit.Framework;
using Rhino.Mocks;

namespace ConfigViewer.Test.Controller
{
    [TestFixture]
    public class HomeController_Tets
    {
        private XDocument _xDoc;
        private IXmlConfigReader _configReader;
        private IXmlConfigWriter _configWriter;
        private XlnConfigCommon _xlnConfigCommon;
        private XlnConfigTelecom _xlnConfigTelecom;
        private IEnumerable<string> _xlnMainSection;
        private HomeController _controller;

        [SetUp()]
        public void SetUp()
        {
            _configReader = MockRepository.GenerateStub<IXmlConfigReader>();
            _configWriter = MockRepository.GenerateStub<IXmlConfigWriter>();
            _xlnConfigCommon = FakePublicWebsiteXml.CreateCommonSection();
            _xlnConfigTelecom = FakePublicWebsiteXml.CreateTelecomSection();
            _xlnMainSection = FakePublicWebsiteXml.CreateXlnMainSection();
            _xDoc = GetFakeXmlFile();
        }

        private static XDocument GetFakeXmlFile()
        {
            return FakePublicWebsiteXml.GetFakePublicWebsite();
        }
    }
}
