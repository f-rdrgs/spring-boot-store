import { Routes } from '@angular/router';
import { MainComponent } from './features/main/main.component';
import { LoginComponent } from './features/auth/login/login.component';


export const AppRoutes: Routes = [
    {
        path:'',
        title:'Main page',
        component: MainComponent
    },
    {
        path:'auth/login',
        title:'Login page',
        component: LoginComponent
    },
    {
        path:'**',
        redirectTo:'',
        title:'Random page',
        pathMatch:'full',
        component: MainComponent
    }
]