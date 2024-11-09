using Common.Application.BasesCommandHandler;
using Mst.AuthManager.Domain.UserAgg.Repository;

namespace Mst.AuthManager.Application.UserAgg.RemoveToken;

public class RemoveTokenCommandHandler : IBaseCommandHandler<RemoveTokenCommand>
{
    public RemoveTokenCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get;}
    public async Task<OperationResult> Handle(RemoveTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetTracking(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        user.RemoveToken(request.TokenId);

        return OperationResult.Success();

    }
}
