using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ConfigViewer.Domain.Entities;

namespace ConfigViewer.Test.FakeData
{
    public class FakePublicWebsiteXml
    {
        public static IEnumerable<string> CreateXlnMainSection()
        {
            List<string> sections = new List<string>();
            sections.Add("common");
            sections.Add("xlntelecom");

            return sections;
        }

        public static XDocument GetFakePublicWebsite ()
        {
            // Create root element
            var xlnFakePublicWebsite = new XDocument();
            var rootElement = new XElement("configs");
            xlnFakePublicWebsite.Add(rootElement);
            
            // Add common section
            var commonSection = CreateCommonSection();
            var commonElement = new XElement("common");
            CreateCommonSection(commonSection, commonElement);
            rootElement.Add(commonElement);

            // Add xln telecom section
            var telecomSection = CreateTelecomSection();
            var telecomElement = new XElement("xlntelecom");
            CreateTelecomSection(telecomSection, telecomElement);

            rootElement.Add(telecomElement);

            return xlnFakePublicWebsite;
        }

        public static XlnConfigCommon CreateCommonSection()
        {
            return new XlnConfigCommon
            {
                ProductionMode = false,
                WcfUrl = "localhost",
                WcfUserName = "thanh",
                WcfPassword = "123",
                CompanyName = "XLN Telecom Ltd.",
                BuildingName = "1st floor",
                StreetName = "Millbank",
                City = "London",
                PostalCode = "SW1P 4QP"
            };
        }

        public static XlnConfigTelecom CreateTelecomSection()
        {
            return new XlnConfigTelecom
            {
                EnableLiveChat = "true",
                ChatPopupTimer = "10000",
                ChatCookieExpirationDays = "30",
                RequireSecure = "true"
            };
        }

        private static void CreateCommonSection(XlnConfigCommon commonSection, XElement commonElement)
        {
            var productionMode = new XElement("ProductionMode", commonSection.ProductionMode);
            commonElement.Add(productionMode);

            var wcfUrl = new XElement("WcfUrl", commonSection.WcfUrl);
            commonElement.Add(wcfUrl);

            var wcfUrerName = new XElement("WcfUserName", commonSection.WcfUserName);
            commonElement.Add(wcfUrerName);

            var wcfPassword = new XElement("WcfPassword", commonSection.WcfPassword);
            commonElement.Add(wcfPassword);

            var companyName = new XElement("CompanyName", commonSection.CompanyName);
            commonElement.Add(companyName);

            var buildingName = new XElement("BuildingName", commonSection.BuildingName);
            commonElement.Add(buildingName);

            var streetName = new XElement("StreetName", commonSection.StreetName);
            commonElement.Add(streetName);

            var city = new XElement("City", commonSection.City);
            commonElement.Add(city);

            var postalCode = new XElement("PostalCode", commonSection.PostalCode);
            commonElement.Add(postalCode);
        }

        private static void CreateTelecomSection(XlnConfigTelecom commonSection, XElement commonElement)
        {
            var enableLiveChat = new XElement("EnableLiveChat", commonSection.EnableLiveChat);
            commonElement.Add(enableLiveChat);

            var chatPopupTimer = new XElement("ChatPopupTimer", commonSection.ChatPopupTimer);
            commonElement.Add(chatPopupTimer);

            var chatCookieExpirationDays = new XElement("ChatCookieExpirationDays", commonSection.ChatCookieExpirationDays);
            commonElement.Add(chatCookieExpirationDays);

            var requireSecure = new XElement("RequireSecure", commonSection.RequireSecure);
            commonElement.Add(requireSecure);     
        }

    }
}
