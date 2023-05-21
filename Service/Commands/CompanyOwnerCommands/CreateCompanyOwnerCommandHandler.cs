using Domain.Models;
using MediatR;
using Repository;
using Services.Commands.CompanyOwnerCommands;

namespace Services.Commands.CompanyOwnerCommands
{
    public class CreateCompanyOwnerCommandHandler : IRequestHandler<CreateCompanyOwnerCommand, CompanyOwner>
    {
        private readonly IRepository<CompanyOwner> _repository;

        public CreateCompanyOwnerCommandHandler(IRepository<CompanyOwner> repository)
        {
            _repository = repository;
        }

        public async Task<CompanyOwner> Handle(CreateCompanyOwnerCommand command, CancellationToken cancellationToken)
        {
            var companyOwner = new CompanyOwner()
            {
                Name = command.Name,
                Password = command.Password,
                EmailAddress = command.EmailAddress,
                PhoneNumber = command.PhoneNumber
            };

            return await _repository.InsertAsync(companyOwner);
        }
    }
}
