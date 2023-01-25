using MediatR;
using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Commands.CompanyCommands
{
    public class CreateCompanyCommandRequest:IRequest<ServiceResponse<Company>>
    {
        public string Name { get; set; }
        public bool IsConfirmed { get; set; }
        public string OrderStartTime { get; set; }
        public string OrderEndTime { get; set; }
    }
}
