using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.CompanyOwnerStories
{
    public class CreateCompanyOwnerStory : IRequest<CompanyOwner>
    {
        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }

        [MaxLength(14, ErrorMessage = "Password too long!")]
        [MinLength(8, ErrorMessage = "Password too short!")]
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string EmailAddress { get; set; }

        [RegularExpression("^(\\+7)[\\ ](\\d{3})[\\ ](\\d{3})[\\ ](\\d{2})[\\ ](\\d{2})$",
            ErrorMessage = "Please enter valid phone number like this: +7 777 777 77 77.")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string PhoneNumber { get; set; }
    }
}

