using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Types
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
