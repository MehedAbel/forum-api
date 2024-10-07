namespace Forum.API.DTOs;

public record class UserDTO(
    int Id,
    string Username,
    string Email
);