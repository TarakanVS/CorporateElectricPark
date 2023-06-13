using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ServiceStories
{
    public class AddChargeSessionStory : IRequest<bool>
    {
        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string SessionNumber { get; set; }

        [Range(0, 999999)]
        [Required(ErrorMessage = "Field can't be empty")]
        public double EnergySpent { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Field can't be empty")]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Field can't be empty")]
        public DateTime FinishDateTime { get; set; }

        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string CarNumberPlate { get; set; }

        [RegularExpression("^(\\+7)[\\ ](\\d{3})[\\ ](\\d{3})[\\ ](\\d{2})[\\ ](\\d{2})$",
            ErrorMessage = "Please enter valid phone number like this: +7 777 777 77 77.")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string DriverPhoneNumber { get; set; }
    }
}
