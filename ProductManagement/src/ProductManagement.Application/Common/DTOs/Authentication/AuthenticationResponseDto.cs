namespace ProductManagement.Application.DTOs.Authentication
{
    public record AuthenticationResponseDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);
}
