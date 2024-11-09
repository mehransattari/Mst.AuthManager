using Common.Domain.Bases;
using Mst.AuthManager.Domain.RoleAgg.Enums;

namespace Mst.AuthManager.Domain.RoleAgg;

public class RolePermission : BaseEntity
{
    #region Properties
    public long RoleId { get; internal set; }
    public Permission Permission { get; private set; }
    #endregion

    #region Constructors
    public RolePermission(Permission permission)
    {
        Permission = permission;
    }
    #endregion
}
