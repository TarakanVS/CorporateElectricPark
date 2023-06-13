using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.CompanyStories
{
    public class CreateCompanyStory : IRequest<Company>
    {
        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string EmailAddress { get; set; }

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
