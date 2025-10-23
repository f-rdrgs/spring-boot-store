import { Component, importProvidersFrom } from '@angular/core';
import { LoginComponent } from './features/auth/login/login.component';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NavBarComponent } from './core/layout/nav-bar/nav-bar.component';
import { RouterModule, RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: "./app.component.html",
  styleUrls: ['./app.component.css'],
  standalone:true,
  providers: [
    // BrowserModule,
    // AppRoutingModule,
    // HttpClientModule,
    // ReactiveFormsModule,
    // RouterModule,
  ],
  imports: [NavBarComponent, RouterOutlet]
})
export class AppComponent {
  title = 'Spring Store';
}
