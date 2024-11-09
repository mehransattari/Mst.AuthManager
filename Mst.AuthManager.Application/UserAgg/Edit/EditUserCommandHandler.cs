using Common.Application.BasesCommandHandler;
using Mst.AuthManager.Domain.UserAgg.Repository;
using Mst.AuthManager.Domain.UserAgg.Services;

namespace Mst.AuthManager.Application.UserAgg.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    public EditUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
    {
        UserRepository = userRepository;
        UserDomainService = userDomainService;
    }

    private IUserRepository UserRepository { get; }
    private IUserDomainService UserDomainService { get; }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetTracking(request.Id);
        if (user == null)
            return OperationResult.NotFound();

        user.Edit(request.userName);

        return OperationResult.Success();
    }
}
