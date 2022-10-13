using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Cart
    {
        public int ID { get; set; }
        public int Amount { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
