using Common.Query.Filter;
using Mst.AuthManager.Domain.RoleAgg.Enums;

namespace Mst.AuthManager.Query.RoleAgg.Dtos;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}
