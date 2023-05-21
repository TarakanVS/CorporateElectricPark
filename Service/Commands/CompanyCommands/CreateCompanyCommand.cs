using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.CompanyCommands
{
    public class CreateCompanyCommand : IRequest<Company>
    {
        public CreateCompanyCommand(string? name, string? phoneNumber, double tariff, string? emailAddress, Guid companyOwnerId, double balance, double debt)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Tariff = tariff;
            EmailAddress = emailAddress;
            CompanyOwnerId = companyOwnerId;
            Balance = balance;
            Debt = debt;
        }

        [MaxLength(250, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string EmailAddress { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        [RegularExpression("^(\\+7)[\\ ](\\d{3})[\\ ](\\d{3})[\\ ](\\d{2})[\\ ](\\d{2})$", 
            ErrorMessage = "Please enter valid phone number like this: +7 777 777 77 77.")]
        [Required(ErrorMessage = "Field can't be empty")]
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
