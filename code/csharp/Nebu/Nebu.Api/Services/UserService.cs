using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nebu.Api.Ef;
using Nebu.Api.Models.Users;

namespace Nebu.Api.Services;

public class UserService(NebuContext _db) : IUserService
{
    public async Task<IEnumerable<UserReadModel>> ListUsers()
    {
        return await _db.Set<EfUser>().Select(u => ToReadModel(u)).ToListAsync();
    }

    public async Task<UserReadModel> CreateUser()
    {
        var u = await _db.Set<EfUser>().AddAsync(new EfUser
        {
            Name = "Test user",
            ApiKey = Guid.NewGuid().ToString()
        });
        await _db.SaveChangesAsync();

        return ToReadModel(u.Entity);
    }

    private static UserReadModel ToReadModel(EfUser u)
        => new(u.Id, u.Name, u.ApiKey);
}
