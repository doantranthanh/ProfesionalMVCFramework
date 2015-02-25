using System.Linq;
using System.Web.Mvc;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Entities;

namespace ConfigViewer.Controllers
{
    public class NavigationController : AbstractController
    {
        public NavigationController(IXmlConfigReader configReader, IXmlConfigWriter configWriter) : base(configReader, configWriter)
        {}

        public PartialViewResult Menu()
        {
            var publicWebsiteSections = ConfigReader.GetAllFirstChildElements(XmlPaths.PublicWebSiteConfig,"configs");
            var configSections = ConfigReader.GetAllFirstChildElements(XmlPaths.Configuration, "PublicWebsite");

            var model = new XlnMainSection
            {
                PublicWebsiteSections = publicWebsiteSections.ToList(),
                ConfigurationSections = configSections.ToList(),
            };

            return PartialView(model);
        }
    }
}
