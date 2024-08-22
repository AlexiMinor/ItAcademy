using ItAcademy.Database.Entities;
using MediatR;

namespace ItAcademy.DataAccess.CQS.Queries.Articles;

public class GetArticleByIdQuery : IRequest<Article?>
{
    public Guid Id { get; set; }
}