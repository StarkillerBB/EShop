﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    internal class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int TypeID { get; set; }
    }
}
