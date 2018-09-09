import { AuthGuard } from './core/guards/auth.guard';
import { RouterModule, Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    {
        path: 'about', loadChildren: './about/about.module#AboutModule'
    }, 
    {
        path: 'calculator', loadChildren: './calculator/calculator.module#CalculatorModule'
    },
    {
        path: 'airexchange', loadChildren: './airexchange/airexchange.module#AirexchangeModule'
    },
    {
        path: 'registration', loadChildren: './registration/registration.module#RegistrationModule'
    },
    {
        path: 'auth', loadChildren:'./auth/auth.module#AuthModule'
    },
    {
        path: 'personal-info', loadChildren:'./personal-info/personal-info.module#PersonalInfoModule', canActivate: [AuthGuard]
    },
    {
        path: 'admin', loadChildren:'./admin/admin.module#AdminModule'
    }
];

export const AppRoutes = RouterModule.forRoot(routes);

