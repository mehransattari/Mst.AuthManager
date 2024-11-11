
using Common.Query;
using Mst.AuthManager.Query.RoleAgg.Dtos;

namespace Mst.AuthManager.Query.RoleAgg.GetById;

public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;

