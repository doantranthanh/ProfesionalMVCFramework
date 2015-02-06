using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AppointmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id)
        {
            return View("Index", (object)id);
        }

        public ViewResult AppointmentData(string id)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd/MM/yyyy";

            IEnumerable<Appointment> data = new[] {
                new Appointment { ClientName = "Joe", Date = DateTime.ParseExact("12/01/2012",format, provider )},
                new Appointment { ClientName = "Joe", Date = DateTime.ParseExact("12/01/2012",format, provider )},
                new Appointment { ClientName = "Joe", Date = DateTime.ParseExact("13/01/2012",format, provider )},
                new Appointment { ClientName = "Jane", Date = DateTime.ParseExact("20/01/2012",format, provider )},
                new Appointment { ClientName = "Jane", Date = DateTime.ParseExact("22/01/2012",format, provider )},
                new Appointment { ClientName = "Bob", Date = DateTime.ParseExact("25/02/2012",format, provider )},
                new Appointment { ClientName = "Bob", Date = DateTime.ParseExact("25/03/2013",format, provider )}
            };

            if (!string.IsNullOrEmpty(id) && id != "All")
            {
                data = data.Where(d => d.ClientName == id);
            }

            return View(data);
        }
    }
}