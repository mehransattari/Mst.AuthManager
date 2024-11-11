using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Mst.AuthManager.Infrastructure.Persistent.Ef;
using Mst.AuthManager.Query.UserAgg.Dtos;

namespace Mst.AuthManager.Query.UserAgg.GetByFilter;

public class GetUserFilterQueryHandler : IQueryHandler<GetUserFilterQuery, UserFilterResult>
{
    private ApplicationDbContext Context { get;}
    private IMapper Mapper { get; }

    public GetUserFilterQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }


    public async Task<UserFilterResult> Handle(GetUserFilterQuery request, CancellationToken cancellationToken)
    {
        var _params = request.FilterParams;

        var result = Context.Users.OrderByDescending(x => x.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(_params.UserName))
            result = result.Where(x => x.Username.Contains(_params.UserName));

        if (_params.Id != null)
            result = result.Where(x => x.Id == _params.Id);

        var skip = (_params.PageId - 1) * _params.Take;

        var model = new UserFilterResult()
        {
            Data = await result.Skip(skip)
                               .Take(_params.Take)
                               .Select(user => new UserFilterData()
                               {
                                   Id = user.Id,
                                   CreationDate = user.CreationDate,

                               }).ToListAsync(cancellationToken),

            FilterParams = _params  
        };

        model.GeneratePaging(result,_params.Take, _params.PageId);

        return model;
    }
}