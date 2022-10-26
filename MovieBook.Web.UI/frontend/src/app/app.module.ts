import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { MoviesComponent } from './components/movies/movies.component';
import { DeleteMovieComponent } from './components/delete-movie/delete-movie.component';
import { NewMovieComponent } from './components/new-movie/new-movie.component';
import { ShowMovieComponent } from './components/show-movie/show-movie.component';
import { UpdateMovieComponent } from './components/update-movie/update-movie.component';
import { MovieService } from './services/movie.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MoviesComponent,
    DeleteMovieComponent,
    NewMovieComponent,
    ShowMovieComponent,
    UpdateMovieComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'movies', component: MoviesComponent},
      { path: 'new-movie', component: NewMovieComponent},
      { path: 'update-movie/:id', component: UpdateMovieComponent},
      { path: 'delete-movie/:id', component: DeleteMovieComponent},
      { path: 'show-movie/:id', component: ShowMovieComponent}
    ])
  ],
  providers: [MovieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
