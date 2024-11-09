using Common.Application.BasesCommandHandler;
using Mst.AuthManager.Domain.RoleAgg;
using Mst.AuthManager.Domain.RoleAgg.Repository;

namespace Mst.AuthManager.Application.RoleAgg.Edit;

public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
{
    public EditRoleCommandHandler(IRoleRepository roleRepository)
    {
        RoleRepository = roleRepository;
    }

    public IRoleRepository RoleRepository { get;}
    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await RoleRepository.GetTracking(request.Id);

        if(role == null) 
        {
            return OperationResult.NotFound();
        }

        role.Edit(request.Title);

        var rolePermissions = new List<RolePermission>();

        request.Permissions.ForEach(per => rolePermissions.Add(new RolePermission(per)));

        role.SetPermissions(rolePermissions);

        await RoleRepository.Save();

        return OperationResult.Success();
    }
}
