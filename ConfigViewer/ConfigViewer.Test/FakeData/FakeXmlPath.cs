using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigViewer.Domain.Entities;

namespace ConfigViewer.Test.FakeData
{
    public class FakeXmlPath
    {
        public static XmlPath CrateXmlPaths()
        {
            return new XmlPath
            {
                PublicWebSiteConfig = @"D:\00.Web Team\02.Projects\ConfigViewer\ConfigViewer\Resources\configs\PublicWebsiteConfig.xml",
                Configuration = @"D:\00.Web Team\02.Projects\ConfigViewer\ConfigViewer\Resources\configs\configuration.xml"
            };
        }
    }
}
