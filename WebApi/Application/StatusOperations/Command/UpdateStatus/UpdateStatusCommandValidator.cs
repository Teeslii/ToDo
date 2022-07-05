using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.StatusOperations.Command.UpdateStatus
{
    public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusCommandValidator()
        {
            RuleFor(command => command.UpdateModel.Name).MinimumLength(2).When( x => x.UpdateModel.Name.Trim() != string.Empty);
            RuleFor(command => command.StatusId).GreaterThan(0);
        }
    }
}