using System;
using Forum.API.DTOs;
using Forum.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Forum.API.Endpoints;

public static class UsersEndpoints
{
    const string getUserEndpointName = "GetUser";

    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app) {
        var group = app.MapGroup("/users");

        // GET /users
        group.MapGet("/", async (ApplicationDbContext dbContext) => {
            var users = await dbContext.Users.Select(x => x.ToUserDTO()).ToListAsync();
            return Results.Ok(users);
        });

        // GET /users/{id}
        group.MapGet("/{id}", (int id, ApplicationDbContext dbContext) => {
            User? user = dbContext.Users.Find(id);

            return user is null ? Results.NotFound() : Results.Ok(user.ToUserDTO());
        })
        .WithName(getUserEndpointName);

        // POST /users/register
        group.MapPost("/register", (RegisterUserDTO registerUserDTO, ApplicationDbContext dbContext) => {
            User user = registerUserDTO.ToEntity();
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            
            return Results.CreatedAtRoute(getUserEndpointName, new { id = user.Id }, user.ToUserDetailsDTO());
        });

        // POST /users/login
        group.MapPost("/login", (LoginUserDTO loginUserDTO, ApplicationDbContext dbContext) => {
            User? user = dbContext.Users.FirstOrDefault(x => x.Username == loginUserDTO.Username && x.Password == loginUserDTO.Password);

            return user is null ? Results.NotFound() : Results.Ok(user.ToUserDetailsDTO());
        });
        

        return group;   
    }
}
