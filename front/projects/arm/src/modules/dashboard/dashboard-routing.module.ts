import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from '../../components';

const routes: Routes = [{
    path: '', component: DashboardComponent, children: [{
        path: 'users',
        loadChildren: () => import('../../modules/users/users.module')
            .then(m => m.UsersModule)
    },
        { path: 'lori', loadChildren: () => import('../../modules/lori/lori.module').then(m => m.LoriModule) },
        { path: '**', redirectTo: '' }
    ]
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DashboardRoutingModule {}
