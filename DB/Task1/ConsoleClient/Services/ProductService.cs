using ConsoleClient.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Services
{
    public class ProductService
    {
        public ProductEntity GetProductById(int id)
        {
            using (var ctx = new OnlineShopContext())
            {
                var product = ctx.Products.FirstOrDefault(p => p.Id == id) ?? throw new ArgumentNullException("Product with provided id not found!");

                return new ProductEntity
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price
                };
            }
        }
    }
}
