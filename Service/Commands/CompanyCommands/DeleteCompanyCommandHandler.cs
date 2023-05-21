using Domain.Models;
using MediatR;
using Repository;
using Services.Commands.CompanyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.CompanyCommands
{
    internal class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Company>
    {
        private readonly IRepository<Company> _repository;

        public DeleteCompanyCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync(command.Id);
            if (company == null)
                return default;

            return await _repository.DeleteAsync(company.Id);
        }
    }
}
