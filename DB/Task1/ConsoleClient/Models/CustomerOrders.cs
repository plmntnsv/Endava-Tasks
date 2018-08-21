using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Models
{
    public class CustomerOrders
    {
        public string FullName { get; set; }
        public Order Order { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
