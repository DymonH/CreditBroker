import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';
// @ts-ignore
import * as usersData from '../../mocks/users.json';

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
    public configuration: Config;
    public columns: Columns[];
    public data: object[] = usersData.default;
    @ViewChild('activeTemplate', {
        static: true
    }) activeTemplate: TemplateRef<any>;
    @ViewChild('fullNameTemplate', {
        static: true
    }) fullNameTemplate: TemplateRef<any>;

    ngOnInit(): void {
        this.configuration = { ...DefaultConfig };
        this.columns = [
            {
                key: 'fullName',
                title: 'Фио',
                cellTemplate: this.fullNameTemplate
            },
            { key: 'department', title: 'Подразделение' },
            { key: 'position', title: 'Должность' },
            { key: 'email', title: 'E-mail' },
            { key: 'phone', title: 'Телефон' },
            { key: 'birthDate', title: 'Дата рождения' },
            {
                key: 'active',
                title: 'Активен',
                cellTemplate: this.activeTemplate
            },
        ];
    }
}
