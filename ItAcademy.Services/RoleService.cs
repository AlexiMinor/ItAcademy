using System.Security.Cryptography;
using System.Text;
using ItAcademy.DataAccess.CQS.Commands.Roles;
using ItAcademy.Database;
using ItAcademy.Database.Entities;
using ItAcademy.Services.Abstractions;
using ItAcademy.Services.Abstractions.Test;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.Services;

public class RoleService : IRoleService
{
    private readonly IMediator _mediator;

    public RoleService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task CreateRoleAsync(string name, CancellationToken token)
    {
        var createRoleCommand = new CreateRoleCommand()
        {
            Name = name
        };
        await _mediator.Send(createRoleCommand, token);
    }

    public async Task SetUserToRole(Guid userId, string roleName, CancellationToken token)
    {
        var setUserRoleCommand = new SetUserRoleCommand()
        {
            RoleName = roleName,
            UserId = userId
        };
        await _mediator.Send(setUserRoleCommand, token);
    }
}