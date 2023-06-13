using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ServiceStories
{
    public class AddChargeSessionStoryHandler : IRequestHandler<AddChargeSessionStory, bool>
    {
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        public AddChargeSessionStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddChargeSessionStory story, CancellationToken cancellationToken)
        {
            var chargeSession = new ChargeSession();
            var car = await _repository.GetByPredicateAsync<Car>(x => x.NumberPlate == story.CarNumberPlate);
            var driver = await _repository.GetByPredicateAsync<Driver>(x => x.PhoneNumber == story.DriverPhoneNumber);

            chargeSession.SessionNumber = story.SessionNumber;
            chargeSession.DriverId = driver.Id;
            chargeSession.CarId = car.Id;
            chargeSession.EnergySpent = story.EnergySpent;
            chargeSession.StartDateTime = story.StartDateTime;
            chargeSession.FinishDateTime = story.FinishDateTime;
            chargeSession.Duration = TimeOnly.FromTimeSpan(chargeSession.FinishDateTime.Subtract(chargeSession.StartDateTime));

            if (car.CompanyId != driver.CompanyId)
            {
                return false;
            }

            var company = await _repository.GetByIdAsync<Company>(driver.CompanyId);
            double tariff;

            if (car.Tariff < company.Tariff)
            {
                tariff = car.Tariff;
            }
            else tariff = company.Tariff;

            chargeSession.Cost = (story.EnergySpent / 1000) * tariff;

            if(chargeSession.Cost > company.Balance)
            {
                company.Balance = 0;
                company.Debt = (company.Balance - chargeSession.Cost) * -1;
            }

            company.Balance -= chargeSession.Cost;
            chargeSession.Debt = company.Debt;

            await _repository.UpdateAsync(company);
            await _repository.InsertAsync(chargeSession);

            return true;
        }
    }
}
