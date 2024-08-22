using ItAcademy.Database.Entities;
using MediatR;

namespace ItAcademy.DataAccess.CQS.Queries.Tokens;

public class GetRefreshTokenByIdQuery : IRequest<RefreshToken?>
{
    public Guid Id { get; set; }
}