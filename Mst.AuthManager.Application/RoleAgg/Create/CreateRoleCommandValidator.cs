using Common.Application.Validation;
using FluentValidation;

namespace Mst.AuthManager.Application.RoleAgg.Create;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}
