import { NgModule, Injector } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from '../../components';
import { LoginRoutingModule } from './login-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AppInjector } from '../../services/app-injector.service';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        LoginRoutingModule,
        SharedModule
    ],
    declarations: [
        LoginComponent
    ]
})
export class LoginModule {
    constructor(injector: Injector) {
        AppInjector.setInjector(injector);
    }
}
