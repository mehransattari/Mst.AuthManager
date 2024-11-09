using Mst.AuthManager.Domain.UserAgg.Repository;
using Mst.AuthManager.Domain.UserAgg.Services;

namespace Mst.AuthManager.Application.UserAgg;

public class UserDomianService : IUserDomainService
{
    public UserDomianService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public IUserRepository UserRepository { get;}

    public bool IsUserExist(string userName)
    {
       var result =  UserRepository.Exists(x=>x.Username == userName);
        return result;
    }
}
