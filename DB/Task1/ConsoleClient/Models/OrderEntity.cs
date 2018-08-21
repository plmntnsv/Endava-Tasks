using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Models
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }

        public virtual CustomerEntity Customer { get; set; }

        public virtual ICollection<OrderItemEntity> OrderItems { get; set; }
    }
}
