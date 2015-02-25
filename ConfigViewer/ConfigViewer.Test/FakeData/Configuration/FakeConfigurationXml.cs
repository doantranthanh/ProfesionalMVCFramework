using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ConfigViewer.Domain.Entities;

namespace ConfigViewer.Test.FakeData
{
    public class FakeConfigurationXml
    {
        public static IEnumerable<string> CreateSections()
        {
            List<string> sections = new List<string>();
            sections.Add("MaintenanceMode");    
            return sections;
        } 

        public static XDocument GetFakeWebsiteConfiguration()
        {
            // Create root element
            var xlnFakeConfiguration = new XDocument();
            var rootElement = new XElement("PublicWebsite");
            xlnFakeConfiguration.Add(rootElement);

            // Add maintenance section
            var maintenance = CreateXlnConfiguration();
            CreateMainSection(maintenance, rootElement);

            return xlnFakeConfiguration;
        }

        public static XlnConfiguration CreateXlnConfiguration()
        {
            return new XlnConfiguration
            {
                MaintenanceMode = false
            };
        }

        private static void CreateMainSection(XlnConfiguration mainSection, XElement commonElement)
        {
            var productionMode = new XElement("MaintenanceMode", mainSection.MaintenanceMode);
            commonElement.Add(productionMode);
        }
    }
}
