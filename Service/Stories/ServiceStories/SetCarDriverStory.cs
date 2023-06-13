using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.ServiceStories
{
    public class SetCarDriverStory : IRequest<bool>
    {
        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string CarNumberPlate { get; set; }

        [RegularExpression("^(\\+7)[\\ ](\\d{3})[\\ ](\\d{3})[\\ ](\\d{2})[\\ ](\\d{2})$",
            ErrorMessage = "Please enter valid phone number like this: +7 777 777 77 77.")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string DriverPhoneNumber { get; set; }
    }
}
