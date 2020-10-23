import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { routes } from '../../shared/models/routes';
import { ApplicationService, AuthorizeService } from '../../services';


@Component({
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    // private
    public loginForm: FormGroup;
    private returnUrl: string;

    // public
    public submitting$: BehaviorSubject<boolean> = new BehaviorSubject(false);
    public submitted$: BehaviorSubject<boolean> = new BehaviorSubject(false);
    public isError$: BehaviorSubject<boolean> = new BehaviorSubject(false);

    constructor(
        private applicationService: ApplicationService,
        private authorizeService: AuthorizeService,
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
    ) { }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', [
                Validators.required,
                Validators.maxLength(255),
                Validators.email
            ]],
            password: ['', Validators.required]
        });

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || routes.dashboard;
    }

    public get username(): AbstractControl {
        return this.loginForm != null ? this.loginForm.get('username') : null;
    }

    public get password(): AbstractControl {
        return this.loginForm != null ? this.loginForm.get('password') : null;
    }

    public onSubmit(e) {
        e.preventDefault();

        this.submitted$.next(true);
        if (!this.loginForm.valid) {
            return;
        }

        this.submitting$.next(true);
        this.isError$.next(false);
        this.authorizeService.login(this.username.value, this.password.value)
            .subscribe(
                _ => this.applicationService.navigate(this.returnUrl),
                _ => {
                    this.isError$.next(true);
                    this.submitting$.next(false);
                }
            );
    }
}
