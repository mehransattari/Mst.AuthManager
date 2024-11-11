using Common.Application.BasesCommandHandler;
using Mst.AuthManager.Application.UserAgg.AddToken;
using Mst.AuthManager.Application.UserAgg.Create;
using Mst.AuthManager.Application.UserAgg.Edit;
using Mst.AuthManager.Application.UserAgg.RemoveToken;
using Mst.AuthManager.Domain.UserAgg;
using Mst.AuthManager.Query.UserAgg.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Mst.AuthManager.Facade.UserAgg;

public interface IUserFacade
{
    Task<OperationResult> Create(CreateUserCommand command);
    Task<OperationResult> Edit(EditUserCommand command);
    Task<OperationResult> AddToken(AddTokenCommand command);
    Task<OperationResult> RemoveToken(RemoveTokenCommand command);

    Task<UserDto?>GetUserById(int userId);
    Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);

    Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
    Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken);
}
