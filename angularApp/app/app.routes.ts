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
    }
];

export const AppRoutes = RouterModule.forRoot(routes);

