using ItAcademy.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.CQS.Queries.User;

public class GetUserEmailByIdQueryHandler : IRequestHandler<GetUserEmailByIdQuery, string>
{
    private readonly ArticleAggregatorContext _context;

    public GetUserEmailByIdQueryHandler(ArticleAggregatorContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(GetUserEmailByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Users.SingleOrDefaultAsync(user => user.Id.Equals(request.Id), cancellationToken))?
            .Email;
    }
}