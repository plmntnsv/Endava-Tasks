using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Common.Enums;
using TestApp.Common.Models;
using TestApp.Services.Contracts;
using TestApp.WebClient.Filters;
using TestApp.WebClient.Models;

namespace TestApp.WebClient.Controllers
{
    [AuthorizationFilter]
    public class DashboardController : Controller
    {
        private readonly IUserService service;
        private static readonly Random rnd = new Random();

        public DashboardController(IUserService service)
        {
            this.service = service;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPdf()
        {
            return File("~/Content/Agendas/sample.pdf", "application/pdf", "agenda.pdf");
        }

        public ActionResult PostPdf()
        {
            return View();
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

            return View("Index");
        }

        public ActionResult WriteSql()
        {
            const int NUMBER_OF_DELEGATIONS = 223;
            const int NUMBER_OF_LOCATIONS = 150;

            var locations = new List<LocationPairerModel>()
            {
                new LocationPairerModel() { Name = "McDonalds", Location = LocationType.Restaurant},
                new LocationPairerModel() { Name = "KFC", Location = LocationType.Restaurant},
                new LocationPairerModel() { Name = "Happy", Location = LocationType.Restaurant},
                new LocationPairerModel() { Name = "Soul Kitchen", Location = LocationType.Restaurant},
                new LocationPairerModel() { Name = "Hilton", Location = LocationType.Hotel},
                new LocationPairerModel() { Name = "Holiday Inn", Location = LocationType.Hotel},
                new LocationPairerModel() { Name = "Sheraton", Location = LocationType.Hotel},
                new LocationPairerModel() { Name = "Endava HQ", Location = LocationType.Office},
                new LocationPairerModel() { Name = "Space X HQ", Location = LocationType.Office},
                new LocationPairerModel() { Name = "Ministry of Foreign Affairs", Location = LocationType.Office}
             };

            var finalLocations = new List<LocationViewModel>();

            for (int i = 0, k = 0; i < NUMBER_OF_LOCATIONS; i++, k++)
            {
                if (k == locations.Count)
                {
                    k = 0;
                }

                var location = new LocationViewModel()
                {
                    Name = locations[k].Name + ((i > 9) ? " " + (i / 10) : ""),
                    Longitude = GetCoord(),
                    Latitude = GetCoord(),
                    LocationId = (int)locations[k].Location
                };

                using (StreamWriter writer = new StreamWriter(@"C:\Users\patanasov\Desktop\Locations.txt", true))
                {
                    writer.WriteLine(location);
                }
            }

            var finalDelegations = new List<DelegationViewModel>();

            var delegations = new List<DelegationPairerModel>()
            {
                new DelegationPairerModel(){ Name = "Tech Delegation", Description = "Update technical documentation."},
                new DelegationPairerModel(){ Name = "Greet Delegation", Description = "Prepare greet meeting."},
                new DelegationPairerModel(){ Name = "CEO Delegation", Description = "Plan corporation annual agenda"},
                new DelegationPairerModel(){ Name = "CTO Delegation", Description = "Developing the company''s strategy for using technological resources."},
                new DelegationPairerModel(){ Name = "Internship Comitee", Description = "Start planning for the next group of trainees."},
                new DelegationPairerModel(){ Name = "Presentation Delegation", Description = "Present the company''s next year plan for development."},
                new DelegationPairerModel(){ Name = "Software Delegation", Description = "Develop and implement software."},
                new DelegationPairerModel(){ Name = "Project owners association", Description = "Assisting and providing leadership towards the completion of project tasks."},
                new DelegationPairerModel(){ Name = "Art Delegation", Description = "Teach modern art."},
                new DelegationPairerModel(){ Name = "Sports Delegation", Description = "Change scoring rules."}
            };

            for (int i = 0, k = 0; i < NUMBER_OF_DELEGATIONS; i++, k++)
            {
                if (k == delegations.Count)
                {
                    k = 0;
                }

                var startDate = RandomStartDate();
                var endDate = RandomEndDate(startDate);

                var delegation = new DelegationViewModel()
                {
                    Name = delegations[k].Name + ((i > 9) ? " " + (i / 10) : ""),
                    Description = delegations[k].Description,
                    StartDate = startDate.ToString("yyyyMMdd"),
                    EndDate = endDate.ToString("yyyyMMdd"),
                    AgendaTitle = "agenda" + (k + 1),
                    HostId = 1,
                    LocationId = rnd.Next(1, 10)
                };

                using (StreamWriter writer = new StreamWriter(@"C:\Users\patanasov\Desktop\Delegations.txt", true))
                {
                    writer.WriteLine(delegation);
                }
            }

            return View();
        }

        private string GetCoord()
        {
            var left = rnd.Next(-100, 101);

            var right = rnd.Next(100000, 1000000);

            return string.Join(".", new int[] { left, right });
        }

        private DateTime RandomStartDate()
        {
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return today.AddDays(rnd.Next(1, 31));
        }

        private DateTime RandomEndDate(DateTime startDate)
        {
            return startDate.AddDays(rnd.Next(1, 100));
        }
    }
}