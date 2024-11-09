using Common.Domain.Bases;
using Common.Domain.Exceptions;

namespace Mst.AuthManager.Domain.UserAgg;

public class User : AggregateRoot
{
    #region Properties
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public List<UserToken> Tokens { get; } = new();
    public List<UserRole> Roles { get; } = new();

    #endregion

    #region Constructors
    public User()
    {
    }

    public User(string username, string passwordHash)
    {
        Guard(username, passwordHash);

        Username = username;
        PasswordHash = passwordHash;
    }

    #endregion

    #region Methods

    public void Guard(string userName, string passwordHash)
    {
        NullOrEmptyDomainDataException.CheckString(userName, nameof(userName));
        NullOrEmptyDomainDataException.CheckString(passwordHash, nameof(passwordHash));
    }

    public void Edit(string username)
    {
        NullOrEmptyDomainDataException.CheckString(username, nameof(username));
        Username = username;
    }
   
    public void SetRoles(List<UserRole> roles)
    {
        roles.ForEach(f => f.UserId = Id);
        Roles.Clear();
        Roles.AddRange(roles);
    }
 
    public void AddToken(string hashJwtToken, string hashRefreshToken,
        DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);

        if (activeTokenCount == 3)
            throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

        var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
        token.UserId = Id;
        Tokens.Add(token);
    }

    public string RemoveToken(long tokenId)
    {
        var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
        if (token == null)
            throw new InvalidDomainDataException("invalid TokenId");

        Tokens.Remove(token);
        return token.HashJwtToken;
    }
    #endregion
}

