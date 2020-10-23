import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
    selector: 'app-side-navigation',
    templateUrl: './side-navigation.component.html',
    styleUrls: ['./side-navigation.component.css']
})
export class SideNavigationComponent implements OnInit {
    private _currentActiveToggle: string;
    private _expandLabel: string;
    @Output() menuExpanded = new EventEmitter<boolean>();

    ngOnInit(): void {
        this._expandLabel = 'Развернуть меню';
    }

    onToggleClick(evt) {
        this._currentActiveToggle = evt.target.ariaLabel;
        this._expandLabel = 'Свернуть меню';
        this.menuExpanded.emit(!!this._currentActiveToggle);
    }

    onExpandClick() {
        this._currentActiveToggle = '';
        this._expandLabel = 'Развернуть меню';
        this.menuExpanded.emit(!!this._currentActiveToggle);
    }

    get currentActiveToggle() {
        return this._currentActiveToggle;
    }

    get expandLabel() {
        return this._expandLabel;
    }
}
