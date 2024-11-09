using Common.Application.Validation;
using FluentValidation;

namespace Mst.AuthManager.Application.UserAgg.RemoveToken;

public class RemoveTokenCommandValidator : AbstractValidator<RemoveTokenCommand>
{
    public RemoveTokenCommandValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEqual(0).WithMessage(ValidationMessages.required("شناسه کاربر"));

        RuleFor(x => x.TokenId).NotNull().NotEmpty().WithMessage(ValidationMessages.required("شناسه توکن"));
    }
}