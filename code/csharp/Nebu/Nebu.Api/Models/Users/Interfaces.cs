namespace Nebu.Api.Models.Users;

public interface IUserService
{
    public Task<IEnumerable<UserReadModel>> ListUsers();
    Task<UserReadModel> CreateUser();
}
