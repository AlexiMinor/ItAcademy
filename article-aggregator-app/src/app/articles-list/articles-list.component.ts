import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Article } from '../../models/article';
import { FormsModule } from '@angular/forms';
import { ArticlePreviewCardComponent } from "../article-preview-card/article-preview-card.component";
import { ArticlesService } from '../../services/articles.service';
import { ArticleDetailsComponent } from "../article-details/article-details.component";

@Component({
  selector: 'app-articles-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ArticlePreviewCardComponent, ArticleDetailsComponent],
  templateUrl: './articles-list.component.html',
  styleUrl: './articles-list.component.scss',
})

export class ArticlesListComponent implements OnInit {
  articles: Article[] = [];
  selectedArticle?: Article;

  constructor(private articlesService: ArticlesService)
  {
  }

  ngOnInit(): void {
    this.articles = this.articlesService.getArticles();
  }

  selectArticle(article: Article): void {
    this.selectedArticle = article;
  }
}
