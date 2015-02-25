using System.Web.Configuration;
using System.Web.Mvc;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Entities;

namespace ConfigViewer.Controllers
{
    public class AbstractController : Controller
    {
        public string XmlPath = WebConfigurationManager.AppSettings["xmlPath"];
        public IXmlConfigReader ConfigReader;
        public IXmlConfigWriter ConfigWriter;

        public XmlPath XmlPaths { get; set; }

        public AbstractController(IXmlConfigReader configReader, IXmlConfigWriter configWriter)
        {
            ConfigReader = configReader;
            ConfigWriter = configWriter;
            XmlPaths = ConfigReader.LoadConfigs(typeof(XmlPath), XmlPath, "xmlPath", new XmlPath());
        }
    }
}
