﻿namespace ItAcademy.Database.Entities;

public class Article : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Text { get; set; }
    public string? OriginalUrl { get; set; }
    public DateTime PublicationDate { get; set; }
    public double? Rate { get; set; }

    public Guid SourceId { get; set; }
    public Source Source { get; set; }
    


}