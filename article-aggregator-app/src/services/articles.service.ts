import { Injectable } from '@angular/core';
import { Article } from '../models/article';
import { ARTICLES_STORAGE } from '../models/ARTICLES-STORAGE';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
})
export class ArticlesService {
  constructor() {}

  getArticles(): Article[] {
    return ARTICLES_STORAGE;
  }

  getArticleById(id: Guid): Article | null {
    for (let article of ARTICLES_STORAGE) {
      if (article.articleId.equals(id)) {
        return article;
      } else return null;
    }
    return null;
  }
}
