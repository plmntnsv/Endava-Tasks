using Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDFApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetPdf()
        {
            return File("~/Content/Agendas/sample.pdf", "application/pdf", "agenda.pdf");
        }

        [HttpPost]
        public ActionResult PostPdf(PdfModel file)
        {
            //if (file != null && file.ContentLength > 0)
            //{
            //    string fileExtension = Path.GetExtension(file.FileName);

            //    if (fileExtension == ".pdf")
            //    {
            //        var fileName = Path.GetFileName(file.FileName);
            //        var path = Path.Combine(Server.MapPath("~/Content/Agendas"), fileName);
            //        file.SaveAs(path);
            //        TempData["Uploaded"] = $"Successfully uploaded {fileName}.";
            //    }
            //    else
            //    {
            //        TempData["Uploaded"] = "Selected file is not a valid PDF.";
            //    }
            //}
            //else
            //{
            //    TempData["Uploaded"] = "No file selected.";
            //}

            if (ModelState.IsValid)
            {
                TempData["Uploaded"] = $"Successfully uploaded {file.Name}.";
            }
            else
            {
                TempData["Uploaded"] = "Error";
            }

            return RedirectToAction("Index");
        }
    }
}