using ConsoleClient.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Services
{
    public class OrderService
    {
        public void MakeAnOrder(int customerId, int productId, int quantity)
        {
            using (var ctx = new OnlineShopContext())
            {
                var customer = ctx.Customers.FirstOrDefault(c => c.Id == customerId) ?? throw new ArgumentNullException("Customer with provided id not found!");
                var product = ctx.Products.FirstOrDefault(p => p.Id == productId) ?? throw new ArgumentNullException("Product with provided id not found!");

                var order = new Order()
                {
                    CustomerId = customer.Id,
                    Customer = customer
                };

                var orderItems = new OrderItem()
                {
                    Quantity = quantity,
                    Order = order,
                    Product = product
                };

                ctx.OrderItems.Add(orderItems);
                ctx.SaveChanges();
            }
        }
    }
}
