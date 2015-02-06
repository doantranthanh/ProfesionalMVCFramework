using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class AppointmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Appointment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Appointment(Appointment app)
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new
                {
                    ClientName = app.ClientName,
                    Date = app.Date.ToShortDateString(),
                    TermAccepted = app.TermsAccepted
                });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(string id)
        {
            return View("Index", (object)id);
        }

        public ActionResult AppointmentData(string id)
        {
            IEnumerable<Appointment> data = new[] {
                new Appointment { ClientName = "Joe", Date = DateTime.ParseExact("01/01/2012", "MM/dd/yyyy", null)},
                new Appointment { ClientName = "Joe", Date = DateTime.ParseExact("02/01/2012", "MM/dd/yyyy", null)},
                new Appointment { ClientName = "Joe", Date = DateTime.ParseExact("03/01/2012", "MM/dd/yyyy", null)},
                new Appointment { ClientName = "Jane", Date = DateTime.ParseExact("01/20/2012", "MM/dd/yyyy", null)},
                new Appointment { ClientName = "Jane", Date = DateTime.ParseExact("01/22/2012", "MM/dd/yyyy", null)},
                new Appointment {ClientName = "Bob", Date = DateTime.ParseExact("02/25/2012","MM/dd/yyyy", null)},
                new Appointment {ClientName = "Bob", Date = DateTime.ParseExact("02/25/2013", "MM/dd/yyyy", null)}
            };
            if (!string.IsNullOrEmpty(id) && id != "All")
            {
                data = data.Where(e => e.ClientName == id);
            }

            if (Request.IsAjaxRequest())
            {
                return Json(data.Select(m => new
                {
                    ClientName = m.ClientName,
                    Date = m.Date.ToShortDateString()
                }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(data);
            }   
        }

    }
}
