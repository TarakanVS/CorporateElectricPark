using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CompanyOwnerCommands
{
    public class DeleteCompanyOwnerCommandHandler : IRequestHandler<DeleteCompanyOwnerCommand, CompanyOwner>
    {
        private readonly IRepository<CompanyOwner> _repository;

        public DeleteCompanyOwnerCommandHandler(IRepository<CompanyOwner> repository)
        {
            _repository = repository;
        }

        public async Task<CompanyOwner> Handle(DeleteCompanyOwnerCommand command, CancellationToken cancellationToken)
        {
            var companyOwner = await _repository.GetByIdAsync(command.Id);
            if (companyOwner == null)
                return default;

            return await _repository.DeleteAsync(companyOwner.Id);
        }
    }
}
