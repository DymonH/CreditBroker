import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from '../../services';
import { User } from '../../shared/models';
import { Observable, BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
    public user$: BehaviorSubject<User> = new BehaviorSubject(null);
    public isAdmin$: BehaviorSubject<boolean> = new BehaviorSubject(false);
    public isMenuExpanded: boolean;

    constructor(
        private authorizeService: AuthorizeService,
        private router: Router
    ) { }

    ngOnInit() {
        this.authorizeService.currentUser$.subscribe(x => {
            this.user$.next(x);
            this.isAdmin$.next(x != null && x.isAdmin);
        });
        this.router.navigate(['/dashboard', 'users']);
    }

    onMenuExpanded(isExpanded) {
        this.isMenuExpanded = isExpanded;
    }
}
