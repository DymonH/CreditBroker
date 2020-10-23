import { NgModule } from '@angular/core';
import { CheckboxComponent } from '../../components/shared/checkbox/checkbox.component';
import { InputComponent } from '../../components/shared/input/input.component';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        CheckboxComponent,
        InputComponent
    ],
    imports: [CommonModule],
    exports: [
        CheckboxComponent,
        InputComponent
    ]
})
export class SharedModule {}
