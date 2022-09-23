using BSynchro.Common.Models.Account;
using BSynchro.DAL.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Commands
{
    public class OpenNewAccountCommand : IRequest<OpenNewAccountOutput>
    {
        public OpenNewAccountInput Input { get;}
        public OpenNewAccountCommand(OpenNewAccountInput input)
        {
            Input = input;
        }
    }

    public sealed class OpenNewAccountCommandValidator : AbstractValidator<OpenNewAccountCommand>
    {
        public OpenNewAccountCommandValidator()
        {
            RuleFor(x => x.Input.CustomerId)
               .NotEmpty()
               .Length(24)
               .WithMessage("wrong customer Id");

            RuleFor(x => x.Input.AccountName)
                .Must(m => m == m.ToLower())
                .WithMessage("AccountName must be lowercase");

            RuleFor(x => x.Input.InitialCredit)
                .Must(m => m > 0 && m < 20000)
                .WithMessage("InitialCredit must be between 0 and 20000");
        }
    }
}
