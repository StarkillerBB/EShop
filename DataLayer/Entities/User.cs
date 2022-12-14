using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public bool SoftDelete { get; set; }

        public int RoleId { get; set; }
        public Roles Role { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
