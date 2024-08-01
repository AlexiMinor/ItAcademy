using ItAcademy.DTOs;
using MediatR;

namespace ItAcademy.DataAccess.CQS.Queries.Articles;

public class GetArticlesByPageNumberAndPageSizeQuery : IRequest<ArticleDto[]>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}