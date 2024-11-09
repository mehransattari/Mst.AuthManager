using Common.Application.BasesCommandHandler;
using Mst.AuthManager.Domain.RoleAgg.Enums;

namespace Mst.AuthManager.Application.RoleAgg.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions): IBaseCommand;
