using FluentValidation;
using MediatR;
using static Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Core.Application.Pipelines.Validation;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        IEnumerable<ValidationExceptionModel> errors = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failures => failures != null)
            .GroupBy(
            keySelector: p => p.PropertyName,
            resultSelector: (properyName, errors) => new ValidationExceptionModel { Property = properyName, Errors = errors.Select(e => e.ErrorMessage)}).ToList();

        if (errors.Any()) throw new CrossCuttingConcerns.Exceptions.Types.ValidationException(errors);
        return next();//
    }
}
