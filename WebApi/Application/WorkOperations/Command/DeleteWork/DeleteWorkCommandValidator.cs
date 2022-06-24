using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.WorkOperations.Command.DeleteWork
{
    public class DeleteWorkCommandValidator : AbstractValidator<DeleteWorkCommand>
    {
        public DeleteWorkCommandValidator()
        {
            RuleFor(Command => Command.WorkId).GreaterThan(0);
        }
    }
}