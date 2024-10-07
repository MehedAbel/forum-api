namespace Forum.API.DTOs;

public record class RegisterUserDTO
{
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}
