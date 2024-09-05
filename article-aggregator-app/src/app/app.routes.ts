import { Routes } from '@angular/router';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ArticleDetailsComponent } from './article-details/article-details.component';

export const routes: Routes = [
  { path: '', redirectTo: '/articles', pathMatch: 'full' },
  { path: 'articles', component: ArticlesListComponent },
  { path: 'about', component: AboutUsComponent },
  { path: 'article/:id', component:ArticleDetailsComponent}
];
