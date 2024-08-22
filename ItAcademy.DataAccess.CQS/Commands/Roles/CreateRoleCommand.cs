using MediatR;

namespace ItAcademy.DataAccess.CQS.Commands.Roles;

public class CreateRoleCommand  : IRequest
{
    public string Name { get; set; }
}