import { Article } from './../../models/article';
import { CommonModule } from '@angular/common';
import { Component, Input, type OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticlesService } from '../../services/articles.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-article-details',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './article-details.component.html',
  styleUrl: './article-details.component.scss',
})

export class ArticleDetailsComponent implements OnInit {
  article: Article | null = null;
  constructor(
    private articleService: ArticlesService,
    private route: ActivatedRoute,
  ){}

  ngOnInit(): void {
    const id: Guid = Guid.parse(this.route.snapshot.paramMap.get('id') ?? '');
    if (id.isEmpty()){
      this.article = null;
    }
    else{
      this.article = this.articleService.getArticleById(id);
    }
  }
}
