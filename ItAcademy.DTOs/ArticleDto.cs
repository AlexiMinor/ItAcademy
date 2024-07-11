using System.ComponentModel.DataAnnotations;

namespace ItAcademy.DTOs
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        //[Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Text { get; set; }
        public string? OriginalUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public double? Rate { get; set; }
        public Guid SourceId { get; set; }
        //[Required]
        public string SourceName { get; set; }

    }
}
