using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CompanyCommands
{
    public class GetCompanyByIdCommandHandler : IRequestHandler<GetCompanyByIdCommand, Company>
    {
        private readonly IRepository<Company> _repository;

        public GetCompanyByIdCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(GetCompanyByIdCommand command, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(command.Id);

            return company;
        }
    }
}
