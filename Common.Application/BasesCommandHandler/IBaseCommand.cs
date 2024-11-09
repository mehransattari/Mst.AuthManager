using MediatR;

namespace Common.Application.BasesCommandHandler;

public interface IBaseCommand : IRequest<OperationResult>
{
}
public interface IBaseCommand<TData> : IRequest<OperationResult<TData>>
{
}

