using ItAcademy.Database.Entities;
using ItAcademy.DTOs;
using ItAcademy.MVC.Models;
using Riok.Mapperly.Abstractions;

namespace ItAcademy.MVC.Mappers;

[Mapper]
public static partial class ArticleMapper
{
   [MapProperty(nameof(Article.Id), nameof(ArticleDto.Id))]
   [MapProperty([nameof(Article.Source), nameof(Article.Source.Title)], 
       [nameof(ArticleDto.SourceName)])]
    public static partial ArticleDto? ArticleToArticleDto(Article? article);
    
   [MapProperty(nameof(ArticleDto.Id), nameof(ArticleModel.ArticleId))]
   public static partial ArticleModel? ArticleDtoToArticleModel(ArticleDto? articleDto);

}