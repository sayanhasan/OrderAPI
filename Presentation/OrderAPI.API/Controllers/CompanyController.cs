using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Application.Commands.CompanyCommands;
using OrderAPI.Application.Queries.CompanyQueries;
using System.Net;

namespace OrderAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var response = await _mediator.Send(new GetAllCompaniesQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody]CreateCompanyCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
