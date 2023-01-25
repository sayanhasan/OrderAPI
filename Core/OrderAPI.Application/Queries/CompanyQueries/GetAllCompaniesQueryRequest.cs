using MediatR;
using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Queries.CompanyQueries
{
    public class GetAllCompaniesQueryRequest:IRequest<ServiceResponse<List<Company>>>
    {
    }
}
