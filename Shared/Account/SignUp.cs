using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace SharedValidationExample.Shared.Account
{
    public class SignUp
    {
        public string Email { get; set; }
        public bool SubscribeToNewsletter { get; set; }
    }

    public class SignUpValidator : AbstractValidator<SignUp>
    {
        private readonly IValidateEmail _validateEmail;

        public SignUpValidator(IValidateEmail validateEmail)
        {
            _validateEmail = validateEmail;

            RuleFor(x => x.Email)
                .NotEmpty()
                .MustAsync(BeUnique).WithMessage("Email already registered");
        }

        private async Task<bool> BeUnique(string email, CancellationToken token)
        {
            return await _validateEmail.CheckIfUnique(email, token);
        }
    }
}