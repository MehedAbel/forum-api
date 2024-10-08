using System;
using Forum.API.DTOs;
using Forum.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Forum.API.Endpoints;

public static class AuthEndpoints
{
    // const string getUserEndpointName = "GetUser";

    public static RouteGroupBuilder MapAuthEndpoints(this WebApplication app) {
        var group = app.MapGroup("/auth");

        // POST /auth/register
        group.MapPost("/register", (RegisterUserDTO registerUserDTO, ApplicationDbContext dbContext) => {
            User user = registerUserDTO.ToEntity();
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            
            return Results.Ok(user.ToUserDetailsDTO());
        });

        // POST /auth/login
        group.MapPost("/login", (LoginUserDTO loginUserDTO, ApplicationDbContext dbContext) => {
            User? user = dbContext.Users.FirstOrDefault(x => x.Username == loginUserDTO.Username && x.Password == loginUserDTO.Password);

            return user is null ? Results.NotFound() : Results.Ok(user.ToUserDetailsDTO());
        });
        

        return group;   
    }
}
