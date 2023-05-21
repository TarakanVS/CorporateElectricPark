using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.CompanyCommands;

namespace CorporateElectricPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Company>> GetCompanysListAsync()
        {
            var companies = await _mediator.Send(new GetCompaniesListCommand());

            return companies;
        }

        [HttpGet("companyId")]
        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await _mediator.Send(new GetCompanyByIdCommand() { Id = companyId });

            return company;
        }

        [HttpPost]
        public async Task<Company> CompanyeateCompanyAsync(Company company)
        {
            var newCompany = await _mediator.Send(new CreateCompanyCommand(
                company.Name,
                company.PhoneNumber,
                company.Tariff,
                company.EmailAddress,
                company.CompanyOwnerId,
                company.Balance,
                company.Debt));

            return newCompany;
        }

        [HttpPut]
        public async Task<Company> UpdateStudentAsync(Company company)
        {
            var isCompanyUpdated = await _mediator.Send(new UpdateCompanyCommand(
                company.Id,
                company.Name,
                company.PhoneNumber,
                company.Tariff,
                company.EmailAddress,
                company.CompanyOwnerId,
                company.Balance,
                company.Debt));

            return isCompanyUpdated;
        }

        [HttpDelete]
        public async Task<Company> DeleteCompanyAsync(Guid id)
        {
            return await _mediator.Send(new DeleteCompanyCommand() { Id = id });
        }
    }
}
