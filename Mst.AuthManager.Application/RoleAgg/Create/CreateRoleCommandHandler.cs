using Common.Application.BasesCommandHandler;
using Mst.AuthManager.Domain.RoleAgg;
using Mst.AuthManager.Domain.RoleAgg.Repository;

namespace Mst.AuthManager.Application.RoleAgg.Create;

public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        RoleRepository = roleRepository;
    }

    private IRoleRepository RoleRepository { get;}

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permissions = new List<RolePermission>();

        request.Permissions.ForEach(x =>
        {
            permissions.Add(new RolePermission(x));
        });

        var role = new Role(request.Title, permissions);

        RoleRepository.Add(role);

        await RoleRepository.Save();

        return OperationResult.Success();
    }
}
