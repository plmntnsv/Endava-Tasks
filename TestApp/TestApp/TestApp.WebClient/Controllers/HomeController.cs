using System.Web.Mvc;
using TestApp.Common.Models;
using TestApp.Services.Contracts;

namespace TestApp.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService service;

        public HomeController(IUserService service)
        {
            this.service = service;
        }

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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            service.GetUserById(1);
            return View();
        }

        public ActionResult GetPdf()
        {
            return File("~/Content/Agendas/sample.pdf", "application/pdf", "agenda.pdf");
        }

        [HttpPost]
        public ActionResult PostPdf(PdfModel model)
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
                TempData["Uploaded"] = $"Successfully uploaded {model.PdfFile.FileName}";
            }
            else
            {
                TempData["Uploaded"] = "Error";
            }

            return View("Index", model);
        }
    }
}