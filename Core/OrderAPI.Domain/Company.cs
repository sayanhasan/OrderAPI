using OrderAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Domain
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public bool IsConfirmed { get; set; }
        public TimeSpan OrderStartTime { get; set; }
        public TimeSpan OrderEndTime { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
