import { CalculatorFormComponent } from './calculator-form/calculator-form.component';
import { RouterModule, Routes } from '@angular/router';



const routes: Routes = [
    { path: '', component: CalculatorFormComponent }
];

export const CalculatorRoutes = RouterModule.forChild(routes);

