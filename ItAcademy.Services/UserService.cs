using System.Security.Cryptography;
using System.Text;
using ItAcademy.Database;
using ItAcademy.Database.Entities;
using ItAcademy.Services.Abstractions;
using ItAcademy.Services.Abstractions.Test;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.Services;

public class UserService : IUserService
{
    private readonly ArticleAggregatorContext _context;

    public UserService(ArticleAggregatorContext context)
    {
        _context = context;
    }

    public async Task RegisterUserAsync(string email, string password, CancellationToken token)
    {

        var userRole = (await _context.Roles.SingleOrDefaultAsync(r => r.Name.Equals("User"), token))?
            .Id;

        if (userRole.HasValue)
        {
            var secStamp = Guid.NewGuid().ToString("N");
            var passwordHash = await GetPasswordHash(password, secStamp);
            var user = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                SecurityStamp = secStamp,
                RoleId = userRole.Value
            };
            await _context.Users.AddAsync(user, token);
            await _context.SaveChangesAsync(token);
            
            //todo to improve: email confirm, sms, etc
        }
    }

    private async Task<string> GetPasswordHash(string password, string secStamp)
    {
        using (var md5 = MD5.Create())
        {
            var inputBytes = Encoding.UTF8.GetBytes($"{password}{secStamp}");
            var ms = new MemoryStream(inputBytes);
            var hashBytes = await md5.ComputeHashAsync(ms);
            var hashedPassword = Encoding.UTF8.GetString(hashBytes);
            return hashedPassword;
        }
    }

    public async Task<bool> CheckPassword(string email, string password, CancellationToken token)
    {
        var user = await _context.Users
            .SingleOrDefaultAsync(u 
                => u.Email.Equals(email), cancellationToken: token);

        return user != null 
               && user.PasswordHash.
                   Equals(await GetPasswordHash(password, user.SecurityStamp));
    }

    public async Task<bool> CheckIsEmailRegisteredAsync(string email, CancellationToken token)
    {
        return await _context.Users.AnyAsync(user => user.Email.Equals(email), token);

    }

    public async Task<string> GetUserRoleByIdAsync(Guid id)
    {
        var userRole = (await _context.Users
            .Include(user => user.Role)
            .SingleOrDefaultAsync(user => user.Id == id))?.Role.Name;

        return userRole;
    }

    public async Task<string> GetUserRoleByEmailAsync(string email, CancellationToken token)
    {
        var userRole = (await _context.Users
            .Include(user => user.Role)
            .SingleOrDefaultAsync(user => user.Email.Equals(email),
                cancellationToken: token))?.Role.Name;

        return userRole;
    }
}