using Common.Application.Validation;
using FluentValidation;

namespace Mst.AuthManager.Application.UserAgg.AddToken;

public class AddTokenCommandValidator:AbstractValidator<AddTokenCommand>
{
    public AddTokenCommandValidator()
    {
        RuleFor(x => x.UserId).NotNull()
            .NotEqual(0).WithMessage(ValidationMessages.required("شناسه کاربر"));

        RuleFor(x => x.HashJwtToken).NotNull()
           .NotEmpty().WithMessage(ValidationMessages.required("HashJwtToken"));
    }
}
