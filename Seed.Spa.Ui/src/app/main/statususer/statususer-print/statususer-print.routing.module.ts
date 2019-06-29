import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusUserPrintComponent } from './statususer-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: StatusUserPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  StatusUserPrintRoutingModule {

}