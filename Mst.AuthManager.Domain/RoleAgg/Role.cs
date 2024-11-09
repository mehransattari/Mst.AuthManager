using Common.Domain.Bases;
using Common.Domain.Exceptions;

namespace Mst.AuthManager.Domain.RoleAgg;

public class Role : AggregateRoot
{
    #region Properties
    public string Title { get; private set; }
    public List<RolePermission> Permissions { get; private set; }
    #endregion

    #region Constructors
    private Role()
    {
    }

    public Role(string title, List<RolePermission> permissions)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));

        Title = title;
        Permissions = permissions;
    }

    public Role(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));

        Title = title;
        Permissions = new List<RolePermission>();
    }
    #endregion

    #region Methods
    public void Edit(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        Title = title;
    }

    public void SetPermissions(List<RolePermission> permissions)
    {
        Permissions = permissions;
    }
    #endregion
}