import { Routes } from '@angular/router';
import { MainComponent } from './features/main/main.component';
import { LoginComponent } from './features/auth/login/login.component';

// DO LAZY LOADING, OTHERWISE ALL PAGES ARE LOADED

export const AppRoutes: Routes = [
    {
        path:'',
        title:'Main page',
        component: MainComponent
    },
    {
        title:'Login page',
        component: LoginComponent,
        path:'auth/login',
    },
    {
        path:'**',
        redirectTo:'',
        title:'Random page',
        pathMatch:'full',
        component: MainComponent
    },

]