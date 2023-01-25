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
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, ServiceResponse<Company>>
    {
        private readonly IUnitOfWork Worker;

        public CreateCompanyCommandHandler(IUnitOfWork worker)
        {
            Worker = worker;
        }

        public async Task<ServiceResponse<Company>> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await Worker.CompanyWriteRepo.AddAsync(new Company()
                {
                    Name = request.Name,
                    IsConfirmed = request.IsConfirmed,
                    OrderStartTime = TimeSpan.Parse(request.OrderStartTime),
                    OrderEndTime = TimeSpan.Parse(request.OrderEndTime),
                });
                var result = await Worker.CommitAsync();
                //we can check acceptable with validator 
                if (result < -1) return new()
                {
                    StatusCode = (int)HttpStatusCode.NotAcceptable,
                    Message = "Please check parameter",
                    Response = null,
                };
                return new()
                {
                    Message = "Added",
                    Response = model,
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
