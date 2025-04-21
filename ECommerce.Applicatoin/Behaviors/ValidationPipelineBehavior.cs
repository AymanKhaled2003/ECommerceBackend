using FluentValidation;
using MediatR;
using ECommerce.Domain.Shared;

namespace ECommerce.Application.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ResponseModel
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
     TRequest request,
     CancellationToken cancellationToken,
     RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
                return await next();

            var validationTasks = _validators
                .Select(validator => validator.ValidateAsync(request, cancellationToken))
                .ToList();

            await Task.WhenAll(validationTasks);

            var errors = validationTasks
                .SelectMany(validationTask => validationTask.Result.Errors)
                .Where(validationFailure => validationFailure != null)
                .Select(failure => $"{failure.PropertyName} {failure.ErrorMessage}")
                .Distinct()
                .ToArray();

            if (errors.Any())
                return CreateValidationResult<TResponse>(errors);

            return await next();
        }

        private static TResult CreateValidationResult<TResult>(string[] errorMessages)
            where TResult : ResponseModel
        {
            if (typeof(TResult).IsAssignableFrom(typeof(ResponseModel)))
                return (ValidationResult.WithErrors(errorMessages) as TResult)!;

            object validationResult = typeof(ValidationResult<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                .GetMethod(nameof(ValidationResult<TResult>.WithErrors))!
                .Invoke(null, [null, errorMessages])!;

            return (TResult)validationResult;
        }
    }

}


