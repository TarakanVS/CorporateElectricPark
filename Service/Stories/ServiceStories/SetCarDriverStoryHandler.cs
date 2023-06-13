using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ServiceStories
{
    public class SetCarDriverStoryHandler : IRequestHandler<AddChargeSessionStory, bool>
    {
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        public SetCarDriverStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddChargeSessionStory story, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByPredicateAsync<Car>(x => x.NumberPlate == story.CarNumberPlate);
            var driver = await _repository.GetByPredicateAsync<Driver>(x => x.PhoneNumber == story.DriverPhoneNumber);

            if (car == null  || driver == null)
            {
                return false;
            }

            if (car.CompanyId != driver.CompanyId)
            {
                return false;
            }

            car.DriverId = driver.Id;
            driver.CarId = car.Id;

            await _repository.UpdateAsync(car);
            await _repository.UpdateAsync(driver);

            return true;
        }
    }
}
