using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.DriverCommands;

namespace CorporateElectricPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Driver>> GetDriversListAsync()
        {
            var drivers = await _mediator.Send(new GetDriversListCommand());

            return drivers;
        }

        [HttpGet("driverId")]
        public async Task<Driver> GetDriverByIdAsync(Guid driverId)
        {
            var driver = await _mediator.Send(new GetDriverByIdCommand() { Id = driverId });

            return driver;
        }

        [HttpPost]
        public async Task<Driver> DrivereateDriverAsync(Driver driver)
        {
            var newDriver = await _mediator.Send(new CreateDriverCommand(
                driver.Name,
                driver.PhoneNumber,
                driver.EmailAddress,
                driver.CarId,
                driver.CompanyId));

            return newDriver;
        }

        [HttpPut]
        public async Task<Driver> UpdateStudentAsync(Driver driver)
        {
            var isDriverUpdated = await _mediator.Send(new UpdateDriverCommand(
                driver.Id,
                driver.Name,
                driver.PhoneNumber,
                driver.EmailAddress,
                driver.CarId,
                driver.CompanyId));

            return isDriverUpdated;
        }

        [HttpDelete]
        public async Task<Driver> DeleteDriverAsync(Guid id)
        {
            return await _mediator.Send(new DeleteDriverCommand() { Id = id });
        }
    }
}
