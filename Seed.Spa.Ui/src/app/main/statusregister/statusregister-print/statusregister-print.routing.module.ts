import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusRegisterPrintComponent } from './statusregister-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: StatusRegisterPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  StatusRegisterPrintRoutingModule {

}