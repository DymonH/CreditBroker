import { AuthorizeService } from '.';
import { Observable, of, throwError } from 'rxjs';
import { User } from '../shared/models';
import { environment } from '../environments/environment';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthorizeMockService extends AuthorizeService {
    public login(username: string, password: string): Observable<User> {
        if (username != null && username.toLowerCase() == "администратор" && password == "123") {
            var user = this.getUser();
            this._currentUser.next(user);
            return of(user) as Observable<User>;
        }

        return throwError("Unauthorized");
    }

    public refreshToken(): Observable<User> {
        if (environment.skipAuthorization) {
            var user = this.getUser();
            this._currentUser.next(user);
            return of(user) as Observable<User>;
        }

        return throwError("Unauthorized");
    }

    private getUser(): User {
        return new User("Администратор", true);
    }
}