using Common.Application.Validation;
using FluentValidation;

namespace Mst.AuthManager.Application.UserAgg.Edit;

public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(x => x.userName).NotNull().NotEmpty()
            .WithMessage(ValidationMessages.required("نام کاربری"));
    }
}
