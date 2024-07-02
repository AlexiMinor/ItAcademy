using System.ComponentModel.DataAnnotations;

namespace ItAcademy.MVC.Models;

public class ArticleModel
{
    [Required]
    public Guid Id { get; set; }
    [MinLength(3)]
    public string Title { get; set; }
    [MaxLength(1000)]
    //[StringLength()]
    public string? Description { get; set; }
    [Required]
    //[RegularExpression()]

    public string Text { get; set; }
    public DateTime PublicationDate { get; set; }
    [Range(-5,5, ErrorMessage = "Value should have a value between -5 and 5")]
    public double Rate { get; set; }
    [Required]
    //[CreditCard]
    public string SourceName { get; set; }

    //[Compare] -> password confirmation
    //[Remote] -> require JS to run, use AJAX, 
}