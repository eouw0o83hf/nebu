using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nebu.Api.Ef;
using Nebu.Api.Models.Users;

namespace Nebu.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService _userService) : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<UserReadModel>> ListUsers()
        => _userService.ListUsers();

    [HttpPost]
    public Task<UserReadModel> CreateUser()
        => _userService.CreateUser();
}

