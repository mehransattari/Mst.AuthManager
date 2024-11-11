﻿using Common.Query;
using Common.Query.Filter;
using Mst.AuthManager.Query.UserAgg.Dtos;

namespace Mst.AuthManager.Query.UserAgg.GetByFilter;

public class GetUserFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
{
    public GetUserFilterQuery(UserFilterParams param) : base(param)
    {            
    }
}
