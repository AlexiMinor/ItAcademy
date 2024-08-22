using MediatR;

namespace ItAcademy.DataAccess.CQS.Commands.Roles;

public class SetUserRoleCommand  : IRequest
{
    public string RoleName { get; set; }
    public Guid UserId { get; set; }
}