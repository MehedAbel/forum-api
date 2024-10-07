using System;
using Forum.API.DTOs;

namespace Forum.API.Mapping;

public static class UserMapping
{
    public static UserDTO ToUserDTO(this User user)
    {
        return new UserDTO(
            user.Id,
            user.Username,
            user.Email
        );
    }

    public static UserDetailsDTO ToUserDetailsDTO(this User user)
    {
        return new UserDetailsDTO(
            user.Id,
            user.Username,
            user.Email,
            user.Password
        );
    }

    public static User ToEntity(this RegisterUserDTO registerUserDTO)
    {
        return new User() {
            Username = registerUserDTO.Username,
            Email = registerUserDTO.Email,
            Password = registerUserDTO.Password
        };
    }
}
