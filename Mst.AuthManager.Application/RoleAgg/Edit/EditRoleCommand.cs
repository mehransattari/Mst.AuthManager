using Common.Application.BasesCommandHandler;
using Mst.AuthManager.Domain.RoleAgg.Enums;

namespace Mst.AuthManager.Application.RoleAgg.Edit;

public record EditRoleCommand(long Id, string Title, List<Permission> Permissions) : IBaseCommand;
