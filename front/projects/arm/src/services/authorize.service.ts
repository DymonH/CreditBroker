import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { HttpService } from './http.service';
import { AppInjector } from './app-injector.service';
import { ApplicationService } from './application.service';
import { SignInModel, User } from '../shared/models';

@Injectable()
export class AuthorizeService extends HttpService {
    private isRefreshTokenInProgress = false;

    protected _currentUser: BehaviorSubject<User> = new BehaviorSubject(null);
    public currentUser$ = this._currentUser.asObservable();
    
    constructor(
        httpClient: HttpClient,
        router: Router
    ) {
        super(httpClient);
        this.setBaseUrl();
    }

    public get refreshTokenInProgress(): boolean {
        return this.isRefreshTokenInProgress;
    }

    public login(username: string, password: string): Observable<User> {
        var data = new SignInModel(username, password);
        return this.post("authorize", data)
            .pipe(
                tap(user => {
                    this._currentUser.next(user);
                })
            ) as Observable<User>;
    }

    public refreshToken(): Observable<User> {
        return this.post("authorize/refresh")
            .pipe(
                tap(user => {
                    this._currentUser.next(user);
                })
            ) as Observable<User>;
    }

    //по-хорошему, можно вынести в базовый класс HttpService
    //но тогда получим circular reference
    public setBaseUrl() {
        if (this.baseUrl != null)
            return;
            
        const injector = AppInjector.getInjector();
        if (injector == null)
            return;
        
        const appService = injector.get(ApplicationService);    
        this.baseUrl = appService.baseUrl;
    }
}
