using Mst.AuthManager.Domain.UserAgg;
using Mst.AuthManager.Domain.UserAgg.Repository;
namespace Mst.AuthManager.Infrastructure.Persistent.Ef.UserAgg;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
