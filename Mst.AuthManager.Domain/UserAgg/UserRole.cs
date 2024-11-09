using Common.Domain.Bases;

namespace Mst.AuthManager.Domain.UserAgg;

public class UserRole: BaseEntity
{
    #region Properties
    public long UserId { get; internal set; }
    public long RoleId { get; private set; }
    #endregion

    #region Constructors
    public UserRole(long roleId)
    {
        RoleId = roleId;
    }
    #endregion
}
