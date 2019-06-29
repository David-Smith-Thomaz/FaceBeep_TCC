import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { RegisterPrintComponent } from './register-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: RegisterPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  RegisterPrintRoutingModule {

}