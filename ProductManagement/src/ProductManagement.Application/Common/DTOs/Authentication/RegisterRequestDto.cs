namespace ProductManagement.Application.DTOs.Authentication
{
    public record RegisterRequestDto(
    string FirstName,
    string LastName,
    string Phone,
    string Email,
    string Password);
}
