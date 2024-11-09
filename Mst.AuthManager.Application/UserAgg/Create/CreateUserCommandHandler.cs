using Common.Application.BasesCommandHandler;
using Common.Application.SecurityUtil;
using Mst.AuthManager.Domain.UserAgg;
using Mst.AuthManager.Domain.UserAgg.Repository;
using Mst.AuthManager.Domain.UserAgg.Services;

namespace Mst.AuthManager.Application.UserAgg.Create;

public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
    public CreateUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
    {
        UserRepository = userRepository;
        UserDomainService = userDomainService;  
    }

    private IUserRepository UserRepository { get;}
    private IUserDomainService UserDomainService { get; }


    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = Sha256Hasher.Hash(request.Password);

       var existUser = UserDomainService.IsUserExist(request.UserName);

        if (existUser)
            return OperationResult.Error("این کاربر از قبل موجود میباشد");

        var user = new User(request.UserName, passwordHash);

        UserRepository.Add(user);

        await UserRepository.Save();

        return OperationResult.Success();
    }
}
