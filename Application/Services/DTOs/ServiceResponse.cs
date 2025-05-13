namespace Application.Services.DTOs
{
    public record ServiceResponse(bool Success = false,
        string Message = null!);
}
