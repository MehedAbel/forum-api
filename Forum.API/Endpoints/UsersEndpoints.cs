using System;

namespace Forum.API.Endpoints;

public static class UsersEndpoints
{
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app) {
        var group = app.MapGroup("/users");

        // GET /users
        group.MapGet("/", () => {
            return "Users List ...";
        });

        group.MapGet("/{id}", (int id) => {
            return $"User number: {id}";
        });

        return group;   
    }
}
