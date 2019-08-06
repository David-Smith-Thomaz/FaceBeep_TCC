import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusDoUsuarioPrintComponent } from './statusdousuario-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: StatusDoUsuarioPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  StatusDoUsuarioPrintRoutingModule {

}