using Common.Application.BasesCommandHandler;

namespace Mst.AuthManager.Application.UserAgg.Edit;

public record EditUserCommand(long Id, string userName):IBaseCommand;
