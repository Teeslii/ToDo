using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.WorkOperations.Query.GetWorkDetail
{
    public class GetWorkDetailQueryValidator : AbstractValidator<GetWorkDetailQuery>
    {
        public GetWorkDetailQueryValidator()
        {
            RuleFor(query => query.WorkTitle).MinimumLength(2);
        }
    }
}