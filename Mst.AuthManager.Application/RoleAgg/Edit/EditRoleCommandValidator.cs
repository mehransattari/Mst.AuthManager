using Common.Application.Validation;
using FluentValidation;

namespace Mst.AuthManager.Application.RoleAgg.Edit;

public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage(ValidationMessages.required("شناسه"));

        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}
