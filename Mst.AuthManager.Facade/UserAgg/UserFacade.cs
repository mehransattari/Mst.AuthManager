using Common.Application.BasesCommandHandler;
using MediatR;
using Mst.AuthManager.Application.UserAgg.AddToken;
using Mst.AuthManager.Application.UserAgg.Create;
using Mst.AuthManager.Application.UserAgg.Edit;
using Mst.AuthManager.Application.UserAgg.RemoveToken;
using Mst.AuthManager.Query.UserAgg.Dtos;
using Mst.AuthManager.Query.UserAgg.GetByFilter;
using Mst.AuthManager.Query.UserAgg.GetById;
using Mst.AuthManager.Query.UserAgg.UserTokens.GetByJwtToken;
using Mst.AuthManager.Query.UserAgg.UserTokens.GetByRefreshToken;

namespace Mst.AuthManager.Facade.UserAgg;

internal class UserFacade : IUserFacade
{
    public UserFacade(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get;}
  

    public async Task<OperationResult> Create(CreateUserCommand command)
    {
       var result = await Mediator.Send(command);
        return result;
    }

    public async Task<OperationResult> Edit(EditUserCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }
     

    public async Task<OperationResult> AddToken(AddTokenCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }

    public async Task<OperationResult> RemoveToken(RemoveTokenCommand command)
    {
        var result = await Mediator.Send(command);
        return result;
    }



    public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        var result = await Mediator.Send(new GetUserFilterQuery(filterParams));
        return result;
    }

    public async Task<UserDto?> GetUserById(int userId)
    {
        var result = await Mediator.Send(new GetUserByIdQuery(userId));
        return result;
    }


    public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
    {
        var result = await Mediator.Send(new GetUserTokenByJwtTokenQuery(jwtToken));
        return result;
    }

    public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
    {
        var result = await Mediator.Send(new GetUserTokenByRefreshTokenQuery(refreshToken));
        return result;
    }
}