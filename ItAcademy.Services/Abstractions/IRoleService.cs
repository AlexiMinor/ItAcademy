using ItAcademy.Database.Entities;

namespace ItAcademy.Services.Abstractions;

public interface IRoleService
{
    Task CreateRoleAsync(string name, CancellationToken token);
    Task SetUserToRole(Guid userId, string roleName, CancellationToken token);
}