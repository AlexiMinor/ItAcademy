import { Article } from './../../models/article';
import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-article-preview-card',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './article-preview-card.component.html',
  styleUrl: './article-preview-card.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ArticlePreviewCardComponent {
  @Input() article?: Article;

  // @Output() selectArticleEvent: EventEmitter<Article> = new EventEmitter<Article>();

  // selectArticle(article: Article) : void {

  //   // this.selectArticleEvent.emit(article);
  // }

 }
