﻿using OrderAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Domain
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
