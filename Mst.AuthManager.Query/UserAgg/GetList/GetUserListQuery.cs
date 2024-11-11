using Common.Query;
using Mst.AuthManager.Query.UserAgg.Dtos;

namespace Mst.AuthManager.Query.UserAgg.GetList;

public record GetUserListQuery : IQuery<List<UserDto>>;
