import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainComponent } from '../components';
import { HttpClientModule } from '@angular/common/http';
import { environment } from '../environments/environment';
import { AuthorizeService } from '../services';
import { AuthorizeMockService } from '../services/authorize.mock.service';

@NgModule({
    declarations: [
        AppComponent,
        MainComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppRoutingModule
    ],
    providers: [
        environment.mock
            ? { provide: AuthorizeService, useClass: AuthorizeMockService }
            : AuthorizeService
    ],
    bootstrap: [ AppComponent, MainComponent ]
})
export class AppModule { }
