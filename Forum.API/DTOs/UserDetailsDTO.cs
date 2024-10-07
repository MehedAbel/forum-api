namespace Forum.API.DTOs;

public record class UserDetailsDTO(
    int Id,
    string Username,
    string Email,
    string Password
);
