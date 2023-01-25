using MediatR;
using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Commands.OrderCommands
{
    public class CreateOrderCommandRequest:IRequest<ServiceResponse<Order>>
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
