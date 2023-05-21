using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.CompanyCommands
{
    public class UpdateCompanyCommand : IRequest<Company>
    {
        public UpdateCompanyCommand(Guid id, string? name, string? phoneNumber, double tariff, string? emailAddress, Guid companyOwnerId, double balance, double debt)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Tariff = tariff;
            EmailAddress = emailAddress;
            CompanyOwnerId = companyOwnerId;
            Balance = balance;
            Debt = debt;
        }

        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        [RegularExpression("^(\\+7)[\\ ](\\d{3})[\\ ](\\d{3})[\\ ](\\d{2})[\\ ](\\d{2})$",
            ErrorMessage = "Please enter valid phone number like this: +7 777 777 77 77.")]
        public string PhoneNumber { get; set; }

        [Range(0, 99999, ErrorMessage = "Invalid value")]
        public double Balance { get; set; }

        [Range(0, 99999, ErrorMessage = "Invalid value")]
        public double Debt { get; set; }

        [Range(0, 999, ErrorMessage = "Invalid value")]
        public double Tariff { get; set; }

        public Guid CompanyOwnerId { get; set; }
    }
}
