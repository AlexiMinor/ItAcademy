using ItAcademy.Database.Entities;

namespace ItAcademy.Services.Abstractions;

public interface IUserService
{
    Task RegisterUserAsync(string email, string password, CancellationToken token);
    Task<bool> CheckPassword(string email, string password, CancellationToken token);
    Task<bool> CheckIsEmailRegisteredAsync(string email, CancellationToken token);
    Task<string> GetUserRoleByIdAsync(Guid id);
    Task<string> GetUserRoleByEmailAsync(string modelEmail, CancellationToken token);
}