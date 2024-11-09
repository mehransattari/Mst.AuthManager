using Common.Application.BasesCommandHandler;

namespace Mst.AuthManager.Application.UserAgg.RemoveToken;

public record RemoveTokenCommand(long UserId, long TokenId) : IBaseCommand;
