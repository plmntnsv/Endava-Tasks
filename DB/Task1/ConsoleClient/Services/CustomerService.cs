using ConsoleClient.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Services
{
    public class CustomerService
    {
        public void AddNewCustomer(CustomerEntity customerToAdd)
        {
            using (var ctx = new OnlineShopContext())
            {
                var customer = new Customer
                {
                    Firstname = customerToAdd.FirstName,
                    Lastname = customerToAdd.LastName,
                    PhoneNumber = customerToAdd.PhoneNumber,
                    SecondPhoneNumber = customerToAdd.SecondPhoneNumber,
                    Address = customerToAdd.Address
                };

                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }

        public CustomerEntity GetCustomerById(int id)
        {
            using (var ctx = new OnlineShopContext())
            {
                var customer = ctx.Customers.FirstOrDefault(c => c.Id == id) ?? throw new ArgumentNullException("Customer with provided id not found!");

                return new CustomerEntity
                {
                    Id = customer.Id,
                    FirstName = customer.Firstname,
                    LastName = customer.Lastname,
                    PhoneNumber = customer.PhoneNumber,
                    SecondPhoneNumber = customer.SecondPhoneNumber,
                    Address = customer.Address
                };
            }
        }

        public void UpdateFirstTwoUsers()
        {
            using (var ctx = new OnlineShopContext())
            {
                ctx.Customers.Take(2).ToList().ForEach(c => c.Lastname = "Ivanov");
                ctx.SaveChanges();
            }
        }

        public void DeleteAllIvanovs()
        {
            using (var ctx = new OnlineShopContext())
            {
                ctx.Customers
                    .Where(customer => customer.Lastname == "Ivanov")
                    .ToList()
                        .ForEach(ivanov =>
                        {
                            ctx.Orders.Where(ivanovOrder => ivanovOrder.CustomerId == ivanov.Id)
                            .ToList()
                            .ForEach(order =>
                            {
                                ctx.OrderItems
                                .Where(ivanovOrderItem => ivanovOrderItem.OrderId == order.Id)
                                .ToList()
                                .ForEach(orderItem => ctx.OrderItems.Remove(orderItem));
                                ctx.Orders.Remove(order);
                            });
                            ctx.Customers.Remove(ivanov);
                        });
                
                ctx.SaveChanges();
            }
        }

        public void SkipCustomers(int customerCountToSkip)
        {
            using (var ctx = new OnlineShopContext())
            {
                var cutomers = ctx.Customers.ToList().Skip(customerCountToSkip);
            }
        }

        public int SumAllCustomers()
        {
            using (var ctx = new OnlineShopContext())
            {
                return ctx.Customers.Count();
            }
        }

        public List<CustomerOrders> GetAllCustomersWithOrders()
        {
            using (var ctx = new OnlineShopContext())
            {
                var customers = ctx.Customers.Join(ctx.Orders, 
                                                        c => c.Id, 
                                                        o => o.CustomerId,
                                                        (c, o) => new CustomerOrders
                                                            {
                                                                FullName = c.Firstname + " " + c.Lastname,
                                                                Order = o
                                                            }).ToList();

                return customers;
            }
        }

        public List<CustomerOrders> GetAllCustomersWithAndWithoutOrders()
        {
            using (var ctx = new OnlineShopContext())
            {
                var customers = ctx.Customers.GroupJoin(ctx.Orders,
                                                        c => c.Id,
                                                        o => o.CustomerId,
                                                        (c, oG) => new CustomerOrders
                                                        {
                                                            FullName = c.Firstname + " " + c.Lastname,
                                                            Orders = oG
                                                        }).ToList();

                return customers;
            }
        }
    }
}
