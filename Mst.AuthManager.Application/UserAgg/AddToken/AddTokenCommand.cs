using Common.Application.BasesCommandHandler;

namespace Mst.AuthManager.Application.UserAgg.AddToken;

public record AddTokenCommand(long UserId,string HashJwtToken, string HashRefreshToken,
        DateTime TokenExpireDate, DateTime RefreshTokenExpireDate, string Device) :IBaseCommand;
