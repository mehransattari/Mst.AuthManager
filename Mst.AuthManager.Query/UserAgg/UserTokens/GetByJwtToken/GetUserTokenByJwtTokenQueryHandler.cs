using Common.Query;
using Dapper;
using Mst.AuthManager.Infrastructure.Persistent.Dapper;
using Mst.AuthManager.Query.UserAgg.Dtos;

namespace Mst.AuthManager.Query.UserAgg.UserTokens.GetByJwtToken;

internal class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto?>
{
    private DapperContext DapperContext { get; }

    public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
    {
        DapperContext = dapperContext;
    }

    public async Task<UserTokenDto?> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
    {
        using var connection = DapperContext.CreateConnection();
        var sql = $"SELECT TOP(1) * FROM {DapperContext.UserTokens} WHERE HashJwtToken=@hashJwtToken";
        return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashJwtToken = request.HashJwtToken});
    }
}
