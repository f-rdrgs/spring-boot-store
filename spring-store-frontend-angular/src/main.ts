import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppComponent } from './app/app.component';
import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig as AppConfig } from './app/app.config';


// platformBrowserDynamic().bootstrapModule(AppModule)
//   .catch(err => console.error(err));

  bootstrapApplication(AppComponent,AppConfig).catch((errors) => console.log(errors));