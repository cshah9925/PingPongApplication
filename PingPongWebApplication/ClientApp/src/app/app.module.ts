import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AddPlayerComponent } from './add-player/add-player.component';

import { PlayersProvider } from './providers/PlayersProvider';
import { ConfirmationDialog } from './dialog/dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddPlayerComponent,
    ConfirmationDialog
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'add-player', component: AddPlayerComponent },
      { path: 'edit-player/:id', component: AddPlayerComponent },
    ])
  ],
  providers: [
    PlayersProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
