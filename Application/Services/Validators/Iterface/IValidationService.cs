

using FluentValidation;

namespace Application.Services.Validators.Iterface
{
    public interface IValidationService
    {
        Task ValidateAsync<T>(T model, IValidator<T> _validator);
    }
    
    
}
