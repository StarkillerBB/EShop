using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public bool SoftDelete { get; set; }

        public int TypeID { get; set; }
        
        public Types? Type { get; set; }
        public List<Cart>? Carts { get; set; }
        
    }
}
