import { NgModule, Injector } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { AppInjector } from '../../services/app-injector.service';
import { DashboardComponent } from '../../components';
import { HeaderComponent } from '../../components/header/header.component';
import { SideNavigationComponent } from '../../components/side-navigation/side-navigation.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        CommonModule,
        SharedModule,
        DashboardRoutingModule
    ],
    declarations: [
        DashboardComponent,
        HeaderComponent,
        SideNavigationComponent
    ],
    exports: [ DashboardComponent ],
    providers: [ ]
})
export class DashboardModule {
    constructor(injector: Injector) {
        AppInjector.setInjector(injector);
    }
}
