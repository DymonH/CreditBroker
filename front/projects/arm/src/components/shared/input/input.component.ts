import { Component, Input, ViewEncapsulation } from '@angular/core';

@Component({
    selector: 'app-input',
    templateUrl: './input.component.html',
    styleUrls: ['./input.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class InputComponent {
    @Input() isFilled: boolean;
}
