using Domain.Models;
using MediatR;
using Repository;
using Services.Stories.CarStories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.ServiceStories
{
    public class SetCarTariffStoryHandler : IRequestHandler<SetCarTariffStory, Car>
    {
        private readonly IRepository _repository;

        public SetCarTariffStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(SetCarTariffStory story, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync<Car>(story.CarId);

            entity.Tariff = story.Tariff;

            var updated = await _repository.UpdateAsync<Car>(entity);

            return updated;
        }
    }
}
