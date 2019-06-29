import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TypeUserPrintComponent } from './typeuser-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: TypeUserPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  TypeUserPrintRoutingModule {

}