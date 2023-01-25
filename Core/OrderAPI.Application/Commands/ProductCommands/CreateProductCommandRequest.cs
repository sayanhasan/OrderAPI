using MediatR;
using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Commands.ProductCommands
{
    public class CreateProductCommandRequest:IRequest<ServiceResponse<Product>>
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int CompanyId { get; set; }
    }
}
