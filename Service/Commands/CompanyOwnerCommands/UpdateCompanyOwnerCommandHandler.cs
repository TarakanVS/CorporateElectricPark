using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CompanyOwnerCommands
{
    internal class UpdateCompanyOwnerCommandHandler : IRequestHandler<UpdateCompanyOwnerCommand, CompanyOwner>
    {
        private readonly IRepository<CompanyOwner> _repository;
        public UpdateCompanyOwnerCommandHandler(IRepository<CompanyOwner> repository)
        {
            _repository = repository;
        }

        public async Task<CompanyOwner> Handle(UpdateCompanyOwnerCommand command, CancellationToken token)
        {
            var companyOwner = await _repository.GetByIdAsync(command.Id);

            if (companyOwner == null)
            {
                return default;
            }

            if (command.Name != default)
            {
                companyOwner.Name = command.Name;
            }

            if (command.PhoneNumber != default)
            {
                companyOwner.PhoneNumber = command.PhoneNumber;
            }

            companyOwner.EmailAddress = command.EmailAddress;

            if (command.Password != default)
            {
                companyOwner.Password = command.Password;
            }

            return await _repository.UpdateAsync(companyOwner);
        }
    }
}