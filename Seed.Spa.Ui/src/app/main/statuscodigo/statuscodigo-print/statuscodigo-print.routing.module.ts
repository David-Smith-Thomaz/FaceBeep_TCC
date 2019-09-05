import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusCodigoPrintComponent } from './statuscodigo-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: StatusCodigoPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  StatusCodigoPrintRoutingModule {

}