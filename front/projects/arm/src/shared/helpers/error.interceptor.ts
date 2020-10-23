import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpInterceptor, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable, throwError, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AuthorizeService } from '../../services';
import { routes } from '../../shared/models';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authorizeService: AuthorizeService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<any> {
        return next.handle(request).pipe(
            // handle error response
            catchError(err => {
                if (err.status === 401) {
                    // auto logout if 401 response returned from api
                    this.router.navigate([routes.login], { skipLocationChange: true });
                    return of([]);
                }
            })
        );
    }
}
