namespace Nebu.Api.Models.Users;

public interface IUserService
{
    Task<IEnumerable<UserReadModel>> ListUsers();
    Task<UserReadModel> CreateUser();
}
