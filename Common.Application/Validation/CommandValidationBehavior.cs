using FluentValidation;
using MediatR;
using System.Text;

namespace Common.Application.Validation;

public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{

    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var errors = _validators.Select(x => x.Validate(request))
                                .SelectMany(res => res.Errors)
                                .Where(err => err != null)
                                .ToList();

        if(errors.Any())
        {
            var errorBuilder = new StringBuilder();
            errors.ForEach(err=> errorBuilder.AppendLine(err.ErrorMessage));
            throw new InvalidCommandException(errorBuilder.ToString());
        }

        var response = await next();
        return response;
    }
}
