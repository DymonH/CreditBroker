import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent, UsersComponent } from '../../components';
import { UsersRoutingModule } from './users-routing.module';
import { TableModule } from 'ngx-easy-table';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        UsersRoutingModule,
        TableModule,
        SharedModule,
        ReactiveFormsModule
    ],
    declarations: [
        UsersComponent,
        UserComponent
    ],
})
export class UsersModule {
    constructor() {}
}
