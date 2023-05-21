﻿using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.CompanyOwnerCommands
{
    public class GetCompanyOwnerByIdCommand : IRequest<CompanyOwner>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }
    }
}
