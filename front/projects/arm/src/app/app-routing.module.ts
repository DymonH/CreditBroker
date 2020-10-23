import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from '../components';

const routes: Routes = [{
    path: 'login',
    loadChildren: () => {
        return import('../modules/login/login.module')
            .then(m => m.LoginModule);
    }
}, {
    path: 'dashboard',
    loadChildren: () => {
        return import('../modules/dashboard/dashboard.module')
            .then(m => m.DashboardModule);
    }
}, {
    path: '**',
    component: MainComponent
}];

@NgModule({
    imports: [RouterModule.forRoot(routes, { enableTracing: true })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
