using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Commands.AddressCreate
{
    public class AddressCreateCommandValidator : AbstractValidator<AddressCreateCommandRequest>
    {
        public AddressCreateCommandValidator()
        {
            RuleFor(x => x.Street).NotNull().Length(5,250);
        }
    }
}
