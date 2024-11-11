using Common.Query;
using Mst.AuthManager.Query.UserAgg.Dtos;

namespace Mst.AuthManager.Query.UserAgg.GetById;

public record GetUserByIdQuery(long UserId) : IQuery<UserDto?>;
