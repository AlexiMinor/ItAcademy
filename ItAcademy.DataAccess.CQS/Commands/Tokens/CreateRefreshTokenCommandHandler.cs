using ItAcademy.Database;
using ItAcademy.Database.Entities;
using MediatR;

namespace ItAcademy.DataAccess.CQS.Commands.Tokens;
public class CreateRefreshTokenCommandHandler : IRequestHandler<CreateRefreshTokenCommand, Guid>
{
    private readonly ArticleAggregatorContext _articleAggregatorContext;

    public CreateRefreshTokenCommandHandler(ArticleAggregatorContext articleAggregatorContext)
    {
        _articleAggregatorContext = articleAggregatorContext;
    }

    public async Task<Guid> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var rt = new RefreshToken()
        {
            Id = Guid.NewGuid(),
            DeviceInfo = "localhost",
            UserId = request.UserId,
            ExpireDateTime = DateTime.UtcNow.AddDays(1)
        };
        await _articleAggregatorContext.RefreshTokens.AddAsync(rt, cancellationToken);
        await _articleAggregatorContext.SaveChangesAsync(cancellationToken);
        
        //business logic > approach
        return rt.Id;
    }
}