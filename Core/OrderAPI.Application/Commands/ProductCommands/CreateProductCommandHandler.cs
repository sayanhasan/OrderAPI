using MediatR;
using OrderAPI.Application.Repositories.UnitOfWork;
using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application.Commands.ProductCommands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ServiceResponse<Product>>
    {
        private readonly IUnitOfWork Worker;

        public CreateProductCommandHandler(IUnitOfWork worker)
        {
            Worker = worker;
        }
        public async Task<ServiceResponse<Product>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await Worker.ProductWriteRepo.AddAsync(new Product()
                {
                    Name = request.Name,
                    CompanyId = request.CompanyId,
                    Quantity =request.Quantity,
                    Price = request.Price
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
