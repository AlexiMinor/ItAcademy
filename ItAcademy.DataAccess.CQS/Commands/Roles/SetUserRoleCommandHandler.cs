using ItAcademy.Database;
using ItAcademy.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.DataAccess.CQS.Commands.Roles;

public class SetUserRoleCommandHandler : IRequestHandler<SetUserRoleCommand>
{
    private readonly ArticleAggregatorContext _articleAggregatorContext;

    public SetUserRoleCommandHandler(ArticleAggregatorContext articleAggregatorContext)
    {
        _articleAggregatorContext = articleAggregatorContext;
    }

    public async Task Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _articleAggregatorContext.Roles
            .AsNoTracking().
            SingleOrDefaultAsync(role => role.Name.Equals(request.RoleName), 
                cancellationToken);

        var user = await _articleAggregatorContext.Users.SingleOrDefaultAsync(us =>
            us.Id.Equals(request.UserId), cancellationToken);

        user.RoleId = role.Id;
        
        await _articleAggregatorContext.SaveChangesAsync(cancellationToken);
    }
}