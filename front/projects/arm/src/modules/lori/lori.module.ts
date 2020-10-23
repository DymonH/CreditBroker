import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LoriComponent } from "../../components";
import { LoriRoutingModule } from "./lori-routing.module";

@NgModule({
    imports: [
        CommonModule,
        LoriRoutingModule
    ],
    declarations: [ LoriComponent ],
})
export class LoriModule {
    constructor() {}
}
