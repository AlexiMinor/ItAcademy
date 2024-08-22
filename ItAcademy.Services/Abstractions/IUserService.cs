using ItAcademy.Database.Entities;
using ItAcademy.DTOs;

namespace ItAcademy.Services.Abstractions;

public interface IUserService
{
    Task RegisterUserAsync(string email, string password, CancellationToken token);
    Task<bool> CheckPassword(string email, string password, CancellationToken token);
    Task<bool> CheckIsEmailRegisteredAsync(string email, CancellationToken token);
    Task<string> GetUserRoleByIdAsync(Guid id);
    Task<string> GetUserRoleByEmailAsync(string modelEmail, CancellationToken token);
    Task<Guid?> GetUserIdByEmailAsync(string modelEmail, CancellationToken cancellationToken);
    Task<UserTokenDto> GetUserDataByRefreshToken(Guid id, CancellationToken cancellationToken);
}