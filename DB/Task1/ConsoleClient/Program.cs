using ConsoleClient.Models;
using ConsoleClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            //SeedCustomers();
            //MakeAnOrder();
            //UpdateFirstTwoCustomers();
            //DeleteIvanovs();
            //SkipCustomers(4);
            //SumAllCustomers();
            //GetAllCustomersWithOrders();
            GetAllCustomersWithAndWithoutOrders();
        }

        private static void GetAllCustomersWithAndWithoutOrders()
        {
            var customerService = new CustomerService();
            customerService.GetAllCustomersWithAndWithoutOrders();
        }

        private static void GetAllCustomersWithOrders()
        {
            var customerService = new CustomerService();
            customerService.GetAllCustomersWithOrders();
        }

        private static void SumAllCustomers()
        {
            var customerService = new CustomerService();
            Console.WriteLine(customerService.SumAllCustomers());
        }

        private static void SkipCustomers(int count)
        {
            var customerService = new CustomerService();
            customerService.SkipCustomers(count);
        }

        private static void DeleteIvanovs()
        {
            var customerService = new CustomerService();
            customerService.DeleteAllIvanovs();
        }

        private static void SeedCustomers()
        {
            var customerService = new CustomerService();

            var customers = new List<CustomerEntity>()
            {
                new CustomerEntity
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    PhoneNumber = "0888123321",
                    SecondPhoneNumber = "02123321",
                    Address = "ul. Cherni Vrah"
                },
                new CustomerEntity
                {
                    FirstName = "Gosho",
                    LastName = "Goshev",
                    PhoneNumber = "0887333222",
                    SecondPhoneNumber = "02433789",
                    Address = "ul. Vitoshka"
                },
                new CustomerEntity
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    PhoneNumber = "0888999111",
                    SecondPhoneNumber = "02555888",
                    Address = "ul. Naroden Geroi"
                },
                new CustomerEntity
                {
                    FirstName = "Maria",
                    LastName = "Marieva",
                    PhoneNumber = "0883847273",
                    SecondPhoneNumber = "02666222",
                    Address = "ul. Ierusalim"
                },
                new CustomerEntity
                {
                    FirstName = "Gergana",
                    LastName = "Georgieva",
                    PhoneNumber = "0885656565",
                    SecondPhoneNumber = "02222222",
                    Address = "ul. Bezimenna"
                },
                new CustomerEntity
                {
                    FirstName = "Nikolai",
                    LastName = "Nikolov",
                    PhoneNumber = "0885555666",
                    SecondPhoneNumber = "02666888",
                    Address = "ul. Myrchaevska"
                },
                new CustomerEntity
                {
                    FirstName = "Penka",
                    LastName = "Penkova",
                    PhoneNumber = "0885998877",
                    SecondPhoneNumber = "02222211",
                    Address = "ul. Moskovska"
                },
                new CustomerEntity
                {
                    FirstName = "Konstantin",
                    LastName = "Konstantinov",
                    PhoneNumber = "0887889900",
                    SecondPhoneNumber = "02111122",
                    Address = "ul. Dunno"
                },
                new CustomerEntity
                {
                    FirstName = "Adrian",
                    LastName = "Adrianov",
                    PhoneNumber = "0888001125",
                    SecondPhoneNumber = "02774455",
                    Address = "ul. Ulichna"
                },
                new CustomerEntity
                {
                    FirstName = "Borqna",
                    LastName = "Borqnova",
                    PhoneNumber = "0888123456",
                    SecondPhoneNumber = "02442266",
                    Address = "ul. Podkova"
                },
            };

            customers.ForEach(c => customerService.AddNewCustomer(c));
            Console.WriteLine("Customers seeded successfully!");
            Console.ReadKey();
        }

        private static void MakeAnOrder()
        {
            var orderService = new OrderService();
            orderService.MakeAnOrder(9, 5, 2);
            Console.WriteLine("Order made successfully!");
            Console.ReadKey();
        }

        private static void UpdateFirstTwoCustomers()
        {
            var customerService = new CustomerService();
            customerService.UpdateFirstTwoUsers();
        }
    }
}
