﻿namespace ItAcademy.Database.Entities;

public class Article
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Text { get; set; }
    public DateTime PublicationDate { get; set; }
    public double? Rate { get; set; }
    public Guid SourceId { get; set; }
}