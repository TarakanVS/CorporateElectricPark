﻿using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ChargeSessionStories
{
    public class GetChargeSessionByIdStory : IRequest<ChargeSession>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }
    }
}
