using Common.Application.BasesCommandHandler;

namespace Mst.AuthManager.Application.UserAgg.Create;

public record CreateUserCommand(string UserName, string Password) : IBaseCommand;
