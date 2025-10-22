import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './core/layout/nav-bar/nav-bar.component';
import { MainComponent } from './features/main/main.component';
import { LoginComponent } from './features/auth/login/login.component';
import { NavBarModule } from './core/layout/nav-bar/nav-bar.module';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NavBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
