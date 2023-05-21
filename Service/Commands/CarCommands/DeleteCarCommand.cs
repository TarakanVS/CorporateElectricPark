﻿using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.CarCommands
{
    public class DeleteCarCommand : IRequest<Car>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }
    }
}
