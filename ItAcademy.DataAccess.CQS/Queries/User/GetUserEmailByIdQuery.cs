using MediatR;

namespace ItAcademy.DataAccess.CQS.Queries.User;

public class GetUserEmailByIdQuery : IRequest<string>
{
    public Guid Id { get; set; }
}