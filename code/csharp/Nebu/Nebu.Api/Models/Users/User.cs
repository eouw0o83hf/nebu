namespace Nebu.Api.Models.Users;

public record UserReadModel(
    Guid Id,
    string Name,
    string? ApiKey
)
{ }
