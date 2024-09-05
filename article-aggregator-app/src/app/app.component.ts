import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ArticlesListComponent } from "./articles-list/articles-list.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ArticlesListComponent, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent {
  title = 'article-aggregator-app';
}
