using System.Linq;
using System.Web.Mvc;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Entities;

namespace ConfigViewer.Controllers
{
    public class RecycleAppPoolController : Controller
    {
        private readonly IApplicationPool _applicationPool;

        public RecycleAppPoolController(IApplicationPool applicationPool)
        {
            _applicationPool = applicationPool;
        }

        public ActionResult Index()
        {
            var model = new XlnMainSection
            {
                ApplicationPools = _applicationPool.GetListAppPools().ToList()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult RycycleAppPool(string appPoolName)
        {
           _applicationPool.RecyleApplicationPool(appPoolName);
           return Json(null,JsonRequestBehavior.AllowGet);
        }

    }
}
