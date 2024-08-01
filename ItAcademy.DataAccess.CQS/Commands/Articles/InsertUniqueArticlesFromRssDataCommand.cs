using ItAcademy.DTOs;
using MediatR;

namespace ItAcademy.DataAccess.CQS.Commands.Articles
{
    public class InsertUniqueArticlesFromRssDataCommand : IRequest
    {
        public ArticleDto[] Articles { get; set; }
    }
}
