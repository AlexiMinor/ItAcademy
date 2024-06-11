namespace ItAcademy.MVC.Models;

public class ArticleWithVisitorsModel
{
    public ArticleModel?[] Articles { get; set; }
    public PaginationModel Pagination { get; set; }
}