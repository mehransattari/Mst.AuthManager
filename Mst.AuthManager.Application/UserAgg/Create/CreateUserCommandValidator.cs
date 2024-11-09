using Common.Application.Validation;
using FluentValidation;

namespace Mst.AuthManager.Application.UserAgg.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserName).NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(x => x.Password).NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("رمز عبور"));
    }
}