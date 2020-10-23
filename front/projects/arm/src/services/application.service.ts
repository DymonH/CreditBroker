import { Injectable, Inject } from '@angular/core';
import { HttpService } from './http.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class ApplicationService extends HttpService {
    constructor(
        httpClient: HttpClient,
        private router: Router
    ) {
        super(httpClient);
    }
    
    public hideAppLoader() {
        window.dispatchEvent(new CustomEvent('happylend.loaded', {
            detail: {},
            bubbles: true
        }));
    }

    public navigate(route: string) {
        window.setTimeout(_ => this.router.navigate([ route ], { skipLocationChange: true }));
    }
}
