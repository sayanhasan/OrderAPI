using MediatR;
using OrderAPI.Application.Repositories.UnitOfWork;
using OrderAPI.Domain;
using OrderAPI.Domain.Enums;
using OrderAPI.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Queries.CompanyQueries
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQueryRequest, ServiceResponse<List<Company>>>
    {
        private readonly IUnitOfWork Worker;

        public GetAllCompaniesQueryHandler(IUnitOfWork worker)
        {
            Worker = worker;
        }

        public async Task<ServiceResponse<List<Company>>> Handle(GetAllCompaniesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                string[] includes = { DbTable.Orders.GetName(), DbTable.Products.GetName() };
                var companies = Worker.CompanyReadRepo.GetListByFilter(includes: includes);
                if (companies.Count() == 0) return new()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Data not found",
                    Response = null,
                };
                return new()
                {
                    Message = companies.Count().ToString(),
                    Response = companies.ToList(),
                };

            }
            catch (Exception ex)
            {
                return new()
                {
                    StatusCode = (int)HttpStatusCode.ExpectationFailed,
                    Message = ex.Message,
                    Response = null,
                };
                throw new Exception(ex.Message);
            }
        }
    }
}
