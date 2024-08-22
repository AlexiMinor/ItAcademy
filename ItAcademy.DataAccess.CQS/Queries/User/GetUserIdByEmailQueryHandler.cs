using ItAcademy.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.CQS.Queries.User;

public class GetUserIdByEmailQueryHandler : IRequestHandler<GetUserIdByEmailQuery, Guid?>
{
    private readonly ArticleAggregatorContext _context;

    public GetUserIdByEmailQueryHandler(ArticleAggregatorContext context)
    {
        _context = context;
    }

    public async Task<Guid?> Handle(GetUserIdByEmailQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Users.SingleOrDefaultAsync(user => user.Email.Equals(request.Email), cancellationToken))?
            .Id;
    }
}