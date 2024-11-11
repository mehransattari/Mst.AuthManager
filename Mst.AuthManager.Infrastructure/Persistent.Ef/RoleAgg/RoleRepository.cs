using Mst.AuthManager.Domain.RoleAgg;
using Mst.AuthManager.Domain.RoleAgg.Repository;

namespace Mst.AuthManager.Infrastructure.Persistent.Ef.RoleAgg;

internal class RoleRepository:BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context):base(context)
    {            
    }
}
