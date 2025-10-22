import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  // templateUrl: './app.component.html',
  template: `
  <h1>Welcome to {{title}}!</h1>

  <router-outlet/>
  `,
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Spring Store';
}
