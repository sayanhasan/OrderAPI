using MediatR;
using OrderAPI.Application.Repositories.UnitOfWork;
using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Commands.CompanyCommands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, ServiceResponse<Company>>
    {
        private readonly IUnitOfWork Worker;

        public UpdateCompanyCommandHandler(IUnitOfWork worker)
        {
            Worker = worker;
        }
        public async Task<ServiceResponse<Company>> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await Worker.CompanyReadRepo.GetByIdAsync(request.Id, false);
                if (company == null) return new()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Company not found",
                    Response = null,
                };
                company.Name = request.Name;
                company.IsConfirmed = request.IsConfirmed;
                company.OrderStartTime = TimeSpan.Parse(request.OrderStartTime);
                company.OrderEndTime = TimeSpan.Parse(request.OrderEndTime);
                Worker.CompanyWriteRepo.Update(company);
                int result = await Worker.CommitAsync();
                if (result < -1) return new()
                {
                    StatusCode = (int)HttpStatusCode.NotAcceptable,
                    Message = "Please check parameter",
                    Response = null,
                };
                return new()
                {
                    Message = "Added",
                    Response = company,
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
