import { Component, OnInit, ElementRef } from '@angular/core';
import { ApplicationService, AuthorizeService } from '../services';

@Component({
    selector: 'app-arm',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'arm';
    
    constructor(
        el: ElementRef,
        private applicationService: ApplicationService,
        private authorizeService: AuthorizeService) {
        const attr = el.nativeElement.attributes.getNamedItem('data-baseurl');
        if (attr != null && attr.value != null && attr.value.length > 0) {
            this.applicationService.baseUrl = attr.value;
            authorizeService.baseUrl = attr.value;
        }
    }

    ngOnInit () {
        //check existing cookies by trying to refresh token
        this.authorizeService.refreshToken()
            .subscribe(
                () => this.next(true),
                () => this.next(false)
            )
    }

    private next(isAuthorized: boolean) {
        this.applicationService.hideAppLoader();
        this.applicationService.navigate(isAuthorized ? '/dashboard' : '/login');
    }
}
