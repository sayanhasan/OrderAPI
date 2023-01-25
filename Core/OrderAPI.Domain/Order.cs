using OrderAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Domain
{
    public class Order:BaseEntity
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public Product Product { get; set; }
        public Company Company { get; set; }
    }
}
