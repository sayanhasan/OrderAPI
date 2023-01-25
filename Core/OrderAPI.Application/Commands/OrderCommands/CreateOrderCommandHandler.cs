using MediatR;
using OrderAPI.Application.Repositories.UnitOfWork;
using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Commands.OrderCommands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, ServiceResponse<Order>>
    {
        private readonly IUnitOfWork Worker;

        public CreateOrderCommandHandler(IUnitOfWork worker)
        {
            Worker = worker;
        }
        public async Task<ServiceResponse<Order>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var requestTime = TimeSpan.Parse(request.OrderDate.ToString("HH:mm"));
                var company = await Worker.CompanyReadRepo.GetByIdAsync(request.CompanyId);
                var product = await Worker.ProductReadRepo.GetByIdAsync(request.ProductId);
                if (company == null) return new()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Company not found",
                    Response = null,
                };
                if (product == null) return new()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Product not found",
                    Response = null,
                };
                if (!company.IsConfirmed) return new()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Firma Onaylı Değil",
                    Response = null,
                };
                if (requestTime > company.OrderEndTime || requestTime < company.OrderStartTime) return new()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Firma şuan sipariş almıyor",
                    Response = null,
                };

                var model = await Worker.OrderWriteRepo.AddAsync(new Order()
                {
                    CustomerName = request.CustomerName,
                    ProductId = request.ProductId,
                    CompanyId = request.CompanyId,
                    OrderDate = request.OrderDate,
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
