﻿using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.DriverStories
{
    public class UpdateDriverStory : IRequest<Driver>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }

        [MaxLength(25, ErrorMessage = "String too long!")]
        public string Name { get; set; }

        [MaxLength(14, ErrorMessage = "Password too long!")]
        [MinLength(8, ErrorMessage = "Password too short!")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [RegularExpression("^(\\+7)[\\ ](\\d{3})[\\ ](\\d{3})[\\ ](\\d{2})[\\ ](\\d{2})$",
            ErrorMessage = "Please enter valid phone number like this: +7 777 777 77 77.")]
        public string PhoneNumber { get; set; }

        public Guid CompanyId { get; set; }

        public Guid CarId { get; set; }
    }
}
