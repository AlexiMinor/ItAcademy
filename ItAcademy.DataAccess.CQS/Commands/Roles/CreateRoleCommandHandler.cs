using ItAcademy.Database;
using ItAcademy.Database.Entities;
using MediatR;

namespace ItAcademy.DataAccess.CQS.Commands.Roles;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
{
    private readonly ArticleAggregatorContext _articleAggregatorContext;

    public CreateRoleCommandHandler(ArticleAggregatorContext articleAggregatorContext)
    {
        _articleAggregatorContext = articleAggregatorContext;
    }

    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await _articleAggregatorContext.Roles.AddAsync(new Role()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        }, cancellationToken);
        await _articleAggregatorContext.SaveChangesAsync(cancellationToken);
    }
}