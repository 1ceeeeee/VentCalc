import { RouterModule, Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    {
        path: 'about', loadChildren: './about/about.module#AboutModule',
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
    }
];

export const AppRoutes = RouterModule.forRoot(routes);

