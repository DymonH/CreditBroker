import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoriComponent } from '../../components';

const routes: Routes = [
    {
        path: '', component: LoriComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class LoriRoutingModule {}