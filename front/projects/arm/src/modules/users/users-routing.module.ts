import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent, UsersComponent } from '../../components';

const routes: Routes = [
    { path: '', component: UsersComponent, pathMatch: 'full' },
    { path: ':id', component: UserComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class UsersRoutingModule {}
