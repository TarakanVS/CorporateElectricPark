using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.CompanyOwnerCommands;

namespace CorporateElectricPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyOwnerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyOwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CompanyOwner>> GetCompaniesOwnersListAsync()
        {
            var companiesOwners = await _mediator.Send(new GetCompaniesOwnersListCommand());

            return companiesOwners;
        }

        [HttpGet("companyOwnerId")]
        public async Task<CompanyOwner> GetCompanyOwnerByIdAsync(Guid companyOwnerId)
        {
            var companyOwner = await _mediator.Send(new GetCompanyOwnerByIdCommand() { Id = companyOwnerId });

            return companyOwner;
        }

        [HttpPost]
        public async Task<CompanyOwner> CompanyOwnereateCompanyOwnerAsync(CompanyOwner companyOwner)
        {
            var newCompanyOwner = await _mediator.Send(new CreateCompanyOwnerCommand(
                companyOwner.Name,
                companyOwner.PhoneNumber,
                companyOwner.Password,
                companyOwner.EmailAddress));

            return newCompanyOwner;
        }

        [HttpPut]
        public async Task<CompanyOwner> UpdateStudentAsync(CompanyOwner companyOwner)
        {
            var isCompanyOwnerUpdated = await _mediator.Send(new UpdateCompanyOwnerCommand(
                companyOwner.Id,
                companyOwner.Name,
                companyOwner.PhoneNumber,
                companyOwner.EmailAddress,
                companyOwner.Password));

            return isCompanyOwnerUpdated;
        }

        [HttpDelete]
        public async Task<CompanyOwner> DeleteCompanyOwnerAsync(Guid id)
        {
            return await _mediator.Send(new DeleteCompanyOwnerCommand() { Id = id });
        }
    }
}
