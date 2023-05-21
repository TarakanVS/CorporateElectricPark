using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.AdministratorCommands;

namespace CorporateElectricPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdministratorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Administrator>> GetAdministratorsListAsync()
        {
            var administrators = await _mediator.Send(new GetAdministratorsListCommand());

            return administrators;
        }

        [HttpGet("administratorId")]
        public async Task<Administrator> GetAdministratorByIdAsync(Guid administratorId)
        {
            var administrator = await _mediator.Send(new GetAdministratorByIdCommand() { Id = administratorId });

            return administrator;
        }

        [HttpPost]
        public async Task<Administrator> AdministratoreateAdministratorAsync(Administrator administrator)
        {
            var newAdministrator = await _mediator.Send(new CreateAdministratorCommand(
                administrator.Name,
                administrator.PhoneNumber,
                administrator.Password,
                administrator.EmailAddress));

            return newAdministrator;
        }

        [HttpPut]
        public async Task<Administrator> UpdateStudentAsync(Administrator administrator)
        {
            var isAdministratorUpdated = await _mediator.Send(new UpdateAdministratorCommand(
                administrator.Id,
                administrator.Name,
                administrator.PhoneNumber,
                administrator.EmailAddress,
                administrator.Password));

            return isAdministratorUpdated;
        }

        [HttpDelete]
        public async Task<Administrator> DeleteAdministratorAsync(Guid id)
        {
            return await _mediator.Send(new DeleteAdministratorCommand() { Id = id });
        }
    }
}