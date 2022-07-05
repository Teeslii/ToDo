using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.StatusOperations.Command.CreateStatus
{
    public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
    {
       public CreateStatusCommandValidator()
       {
         RuleFor(command => command.CreateModel.Name).NotEmpty().MinimumLength(2);
       }
    }
}