import { Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';

export abstract class HttpService {
    private _baseUrl: string = null;

    constructor(@Inject(HttpClient) protected http: HttpClient) { }

    public get baseUrl(): string {
        return this._baseUrl;
    }

    public set baseUrl(value: string) {
        this._baseUrl = value;
    }

    protected get options(): any {
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            }),
            responseType: 'json',
            withCredentials: true
        };
    }

    protected get(relativeUrl: string): Observable<any> {
        return this.http.get(this.baseUrl + relativeUrl, this.options);
    }

    protected post(relativeUrl: string, data: any = undefined) {
        return this.http.post(this.baseUrl + relativeUrl, data, this.options)
            .pipe() as Observable<any>;
    }
}
