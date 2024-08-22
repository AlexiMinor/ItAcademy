using ItAcademy.DataAccess.CQS.Queries.User;
using ItAcademy.Database;
using ItAcademy.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.CQS.Queries.Tokens;

public class GetRefreshTokenByIdQueryHandler : IRequestHandler<GetRefreshTokenByIdQuery, RefreshToken?>
{
    private readonly ArticleAggregatorContext _context;

    public GetRefreshTokenByIdQueryHandler(ArticleAggregatorContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken?> Handle(GetRefreshTokenByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.RefreshTokens.SingleOrDefaultAsync(refreshToken => refreshToken.Id.Equals(request.Id), cancellationToken);
    }
}