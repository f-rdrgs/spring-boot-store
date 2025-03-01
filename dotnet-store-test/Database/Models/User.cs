using System;
using System.Collections.Generic;
using dotnet_store_test.Database.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store_test.Database.Models;

public partial class User(string username, string email, string password)
{
    public int Id { get; set; }

    public string Username { get; set; } = username;

    public string Email { get; set; } = email;

    public string Password { get; set; } = password;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<OrdersClient> OrdersClients { get; set; } = new List<OrdersClient>();
}


//public static class UserEndpoints
//{
//	public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
//    {
//        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

//        group.MapGet("/", async (SpringStoreContext db) =>
//        {
//            return await db.Users.ToListAsync();
//        })
//        .WithName("GetAllUsers")
//        .WithOpenApi();

//        group.MapGet("/{id}", async Task<Results<Ok<User>, NotFound>> (int id, SpringStoreContext db) =>
//        {
//            return await db.Users.AsNoTracking()
//                .FirstOrDefaultAsync(model => model.Id == id)
//                is User model
//                    ? TypedResults.Ok(model)
//                    : TypedResults.NotFound();
//        })
//        .WithName("GetUserById")
//        .WithOpenApi();

//        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, User user, SpringStoreContext db) =>
//        {
//            var affected = await db.Users
//                .Where(model => model.Id == id)
//                .ExecuteUpdateAsync(setters => setters
//                  .SetProperty(m => m.Id, user.Id)
//                  .SetProperty(m => m.Username, user.Username)
//                  .SetProperty(m => m.Email, user.Email)
//                  .SetProperty(m => m.Password, user.Password)
//                  );
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("UpdateUser")
//        .WithOpenApi();

//        group.MapPost("/", async (User user, SpringStoreContext db) =>
//        {
//            db.Users.Add(user);
//            await db.SaveChangesAsync();
//            return TypedResults.Created($"/api/User/{user.Id}",user);
//        })
//        .WithName("CreateUser")
//        .WithOpenApi();

//        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, SpringStoreContext db) =>
//        {
//            var affected = await db.Users
//                .Where(model => model.Id == id)
//                .ExecuteDeleteAsync();
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("DeleteUser")
//        .WithOpenApi();
//    }
//}