using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.WorkOperations.Command.CreateWork
{
    public class CreateWorkCommandValidator : AbstractValidator<CreateWorkCommand>
    {
        public CreateWorkCommandValidator()
        {
            RuleFor(command => command.CreateModel.Title).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Content).MaximumLength(120);
            RuleFor(command => command.CreateModel.StatusId).GreaterThan(0);
        }
    }
}