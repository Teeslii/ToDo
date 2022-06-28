using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.WorkOperations.Command.UpdateWork
{
    public class UpdateWorkCommandValidator : AbstractValidator<UpdateWorkCommand>
    {
        public UpdateWorkCommandValidator()
        {
            
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Content).MaximumLength(120);
            RuleFor(command => command.Model.StatusId).GreaterThan(0);
        }
    }
}