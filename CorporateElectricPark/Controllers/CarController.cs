using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.CarCommands;

namespace CorporateElectricPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Car>> GetCarsListAsync()
        {
            var cars = await _mediator.Send(new GetCarsListCommand());

            return cars;
        }

        [HttpGet("carId")]
        public async Task<Car> GetCarByIdAsync(Guid carId)
        {
            var car = await _mediator.Send(new GetCarByIdCommand() { Id = carId });

            return car;
        }

        [HttpPost]
        public async Task<Car> CareateCarAsync(Car car)
        {
            var newCar = await _mediator.Send(new CreateCarCommand(
                car.NumberPlate,
                car.Model,
                car.Tariff,
                car.Mileage,
                car.CompanyId,
                car.DriverId,
                car.CompanyId));

            return newCar;
        }

        [HttpPut]
        public async Task<Car> UpdateStudentAsync(Car car)
        {
            var isCarUpdated = await _mediator.Send(new UpdateCarCommand(
               car.Id,
               car.NumberPlate,
               car.Model,
               car.Mileage,
               car.Tariff,
               car.DriverId, 
               car.CompanyId));

            return isCarUpdated;
        }

        [HttpDelete]
        public async Task<Car> DeleteCarAsync(Guid id)
        {
            return await _mediator.Send(new DeleteCarCommand() { Id = id });
        }
    }
}
