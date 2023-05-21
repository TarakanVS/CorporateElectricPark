﻿using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.CompanyOwnerCommands
{
    public class UpdateCompanyOwnerCommand : IRequest<CompanyOwner>
    {
        public UpdateCompanyOwnerCommand(Guid id, string? name, string? phoneNumber, string? emailAddress, string? password)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Password = password;
        }

        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        public string Name { get; set; }

        [MaxLength(14, ErrorMessage = "Password too long!")]
        [MinLength(8, ErrorMessage = "Password too short!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        [RegularExpression("^(\\+7)[\\ ](\\d{3})[\\ ](\\d{3})[\\ ](\\d{2})[\\ ](\\d{2})$",
            ErrorMessage = "Please enter valid phone number like this: +7 777 777 77 77.")]
        public string PhoneNumber { get; set; }
    }
}