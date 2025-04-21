namespace ECommerce.Domain.Shared;

public interface IValidationResult
{
    string[] ErrorMessages { get; }
}
