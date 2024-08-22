using ItAcademy.Database;
using ItAcademy.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.CQS.Queries.User;

public class GetUserDataByRefreshTokenQueryHandler : IRequestHandler<GetUserDataByRefreshTokenQuery, UserTokenDto?>
{
    private readonly ArticleAggregatorContext _context;

    public GetUserDataByRefreshTokenQueryHandler(ArticleAggregatorContext context)
    {
        _context = context;
    }

    public async Task<UserTokenDto?> Handle(GetUserDataByRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var userId = (await _context.RefreshTokens.AsNoTracking().SingleOrDefaultAsync(
            refreshToken => refreshToken.Id.Equals(request.ToklenId), cancellationToken))?.UserId;
        var user = await _context.Users.Include(u => u.Role)
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id.Equals(userId), cancellationToken);
        if (user != null)
        {
            return new UserTokenDto()
            {
                Id = userId.Value,
                Email = user.Email,
                RoleName = user.Role.Name,
                RefreshToken = request.ToklenId
            };
        }

        return null;
    }
}