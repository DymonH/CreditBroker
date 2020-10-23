import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';
// @ts-ignore
import * as usersData from '../../mocks/users.json';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
    public configuration: Config;
    public columns: Columns[];
    public user = usersData.default[0];
    public userForm: FormGroup;
    public passwordForm: FormGroup;
    @ViewChild('logoutTemplate', {
        static: true
    }) logoutTemplate: TemplateRef<any>;

    constructor(private formBuilder: FormBuilder) {}

    ngOnInit(): void {
        this.configuration = { ...DefaultConfig };
        this.columns = [
            { key: 'name', title: 'Наименование устройства' },
            { key: 'authDate', title: 'Дата и время авторизации' },
            { key: 'authExpire', title: 'Авторизация истекает' },
            {
                key: '',
                title: 'Выйти с устройства',
                cellTemplate: this.logoutTemplate,
                cssClass: { name: 'logout-column', includeHeader: false }
            }
        ];

        this.userForm = this.formBuilder.group({
            username: [this.user.fullName],
            position: [this.user.position],
            department: [this.user.department],
            email: [this.user.email],
            phone: [this.user.phone],
            birthDate: [this.user.birthDate]
        });

        this.passwordForm = this.formBuilder.group({
            passwordNew: [''],
            passwordRepeat: [''],
            passwordCurrent: ['']
        });
    }

    public get username(): AbstractControl {
        return this.userForm.get('username');
    }

    public get position(): AbstractControl {
        return this.userForm.get('position');
    }

    public get department(): AbstractControl {
        return this.userForm.get('department');
    }

    public get email(): AbstractControl {
        return this.userForm.get('email');
    }

    public get phone(): AbstractControl {
        return this.userForm.get('phone');
    }

    public get birthDate(): AbstractControl {
        return this.userForm.get('birthDate');
    }

    public get passwordNew(): AbstractControl {
        return this.passwordForm.get('passwordNew');
    }

    public get passwordRepeat(): AbstractControl {
        return this.passwordForm.get('passwordRepeat');
    }

    public get passwordCurrent(): AbstractControl {
        return this.passwordForm.get('passwordCurrent');
    }
}
