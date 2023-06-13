using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.AdministratorStories
{
    public class DeleteAdministratorStoryHandler : IRequestHandler<DeleteAdministratorStory, Administrator>
    {
        private readonly IRepository _repository;

        public DeleteAdministratorStoryHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Administrator> Handle(DeleteAdministratorStory story, CancellationToken cancellationToken)
        {
            var administrator = await _repository.GetByIdAsync<Administrator>(story.Id);
            if (administrator == null)
                return default;

            return await _repository.DeleteAsync<Administrator>(administrator.Id);
        }
    }
}
