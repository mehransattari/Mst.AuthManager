using Common.Application.BasesCommandHandler;
using Mst.AuthManager.Domain.UserAgg.Repository;

namespace Mst.AuthManager.Application.UserAgg.AddToken;

public class AddTokenCommandHandler : IBaseCommandHandler<AddTokenCommand>
{
    public AddTokenCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }

    public async Task<OperationResult> Handle(AddTokenCommand request, CancellationToken cancellationToken)
    {
        var user =await UserRepository.GetTracking(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        user.AddToken(request.HashJwtToken, request.HashRefreshToken,
            request.TokenExpireDate, request.RefreshTokenExpireDate, request.Device);

        await UserRepository.Save();

        return OperationResult.Success();
    }
}
