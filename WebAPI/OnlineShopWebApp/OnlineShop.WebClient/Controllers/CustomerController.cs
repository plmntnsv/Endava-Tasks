using OnlineShop.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.WebClient.Controllers
{
    public class CustomerController : Controller
    {
        private static readonly List<CustomerViewModel> customers = new List<CustomerViewModel>()
        {
            new CustomerViewModel()
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Phone = "0888123456",
                SecondPhone = "02123456",
                Address = "ul. Narodno Horo 100, zh.k. Ovcha Kupel"
            },
            new CustomerViewModel()
            {
                Id = 2,
                FirstName = "Pesho",
                LastName = "Peshov",
                Phone = "0888123456",
                SecondPhone = "02123456",
                Address = "ul. Borqna 5, zh.k. Ovcha Kupel"
            },
            new CustomerViewModel()
            {
                Id = 3,
                FirstName = "Gosho",
                LastName = "Goshov",
                Phone = "08856789012",
                SecondPhone = "02111222",
                Address = "ul. Vitoshka 200, Centyr"
            },
            new CustomerViewModel()
            {
                Id = 4,
                FirstName = "Ivanka",
                LastName = "Ivankova",
                Phone = "0883555222",
                SecondPhone = "02001122",
                Address = "ul. Rila 30, zh.k. Nadejda"
            },
            new CustomerViewModel()
            {
                Id = 5,
                FirstName = "Gosho",
                LastName = "Goshov",
                Phone = "0886666111",
                SecondPhone = "02159268",
                Address = "ul. Slunce 50, zh.k. Borovo"
            }
        };
        
        public ActionResult All()
        {
            return View(customers);
        }
        
        public ActionResult Delete(int id)
        {
            customers.Remove(customers.Find(c => c.Id == id));
            return View("All", customers);
        }
        
        public ActionResult Edit(int id)
        {
            var customerToEdit = customers.FirstOrDefault(c => c.Id == id);

            if (customerToEdit == null)
            {
                return HttpNotFound();
            }

            return View(customerToEdit);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel model)
        {
            var customerToEdit = customers.FirstOrDefault(c => c.Id == model.Id);

            if (customerToEdit == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                customerToEdit.Id = model.Id;
                customerToEdit.FirstName = model.FirstName;
                customerToEdit.LastName = model.LastName;
                customerToEdit.Phone = model.Phone;
                customerToEdit.SecondPhone = model.SecondPhone;
                customerToEdit.Address = model.Address;
            }
            else
            {
                return View(model);
            }
            

            return View("All", customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}