import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar.component';
import { RouterLink, RouterOutlet } from '@angular/router';



@NgModule({
  declarations: [NavBarComponent],
  imports: [
    CommonModule,
    RouterOutlet, 
    RouterLink
  ],
  exports :[
    NavBarComponent
  ]
})
export class NavBarModule { }
