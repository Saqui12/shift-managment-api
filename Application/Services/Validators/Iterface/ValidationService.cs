

using FluentValidation;

namespace Application.Services.Validators.Iterface
{
    public class ValidationService : IValidationService
    {
        public async Task ValidateAsync<T>(T model, IValidator<T> _validator)
        {
            var result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                string errorString = string.Join("; ", errors);
                throw new ValidationException(errorString);
            }
        }
    }
}
