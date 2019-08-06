import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusDaTurmaPrintComponent } from './statusdaturma-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: StatusDaTurmaPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  StatusDaTurmaPrintRoutingModule {

}