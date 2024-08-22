using MediatR;

namespace ItAcademy.DataAccess.CQS.Queries.User;

public class GetUserIdByEmailQuery  : IRequest<Guid?>
{
    public string Email { get; set; }
}