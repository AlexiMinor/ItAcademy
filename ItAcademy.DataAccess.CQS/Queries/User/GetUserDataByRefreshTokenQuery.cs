using ItAcademy.DTOs;
using MediatR;

namespace ItAcademy.DataAccess.CQS.Queries.User;

public class GetUserDataByRefreshTokenQuery : IRequest<UserTokenDto?>
{
    public Guid ToklenId { get; set; }
}