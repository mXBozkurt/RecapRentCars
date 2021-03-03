using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotNull();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotNull();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.EMail).Must(MailCheck).When(p => p.EMail != null).WithMessage("IsValid Mail");
            RuleFor(p => p.EMail).NotEmpty();
            RuleFor(p => p.EMail).NotNull();
        }

        private bool MailCheck(string arg)
        {
            return arg.Contains("@");
        }
    }
}
