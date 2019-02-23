import { AppErrorHandler } from './app.error-handler';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { StampFormComponent } from './stamp-form/stamp-form.component';
import { StampListComponent } from './stamp-list/stamp-list.component';

import { StampService } from './services/stamp.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    StampFormComponent,
    StampListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    FontAwesomeModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'stamps/new', component: StampFormComponent },
      { path: 'stamps/:id', component: StampFormComponent },
      { path: 'stamps', component: StampListComponent }
    ])
  ],
  providers: [
    {provide: ErrorHandler, useClass: AppErrorHandler},
    StampService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
