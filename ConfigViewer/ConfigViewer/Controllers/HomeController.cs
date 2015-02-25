using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.Linq;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Entities;

namespace ConfigViewer.Controllers
{
    public class HomeController : AbstractController
    {
        public HomeController(IXmlConfigReader configReader, IXmlConfigWriter configWriter) : base(configReader, configWriter)
        {}


        public ViewResult Index()
        {          
            return View();
        }
     
        [HttpGet]
        public ActionResult Common()
        {
            var model = ConfigReader.LoadConfigs(typeof(XlnConfigCommon), XmlPaths.PublicWebSiteConfig, "common", new XlnConfigCommon());
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateCommon(XlnConfigCommon xlnConfigCommon)
        {
            ConfigWriter.UpdateXmlElement(xlnConfigCommon, XmlPaths.PublicWebSiteConfig, "configs", "common", xlnConfigCommon);
            ConfigWriter.SaveXmlFile(XmlPaths.PublicWebSiteConfig);
            return Json(xlnConfigCommon, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult MaintenanceMode()
        {
            var model = ConfigReader.LoadConfigs(typeof(XlnConfiguration), XmlPaths.Configuration, "PublicWebsite", new XlnConfiguration());
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateMaintenanceMode(XlnConfiguration xlnConfiguration)
        {
            ConfigWriter.UpdateXmlElement(xlnConfiguration, XmlPaths.Configuration, "PublicWebsite", "MaintenanceMode", xlnConfiguration);
            ConfigWriter.SaveXmlFile(XmlPaths.Configuration);
            return Json(xlnConfiguration, JsonRequestBehavior.AllowGet);
        }
    }
}
