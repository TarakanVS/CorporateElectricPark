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
    public class ShowCompanyCarsStoryHandler : IRequestHandler<ShowCompanyCarsStory, List<Car>>
    {
        private readonly IRepository _repository;

        public ShowCompanyCarsStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Car>> Handle(ShowCompanyCarsStory story, CancellationToken cancellationToken)
        {
            var list = await _repository.GetByPredicateAsync<Car>(x => x.CompanyId == story.CompanyId);

            return list;
        }
    }
}
