namespace Mst.AuthManager.Domain.UserAgg.Services;

public interface IUserDomainService
{
    bool IsUserExist(string userName);
}
