import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UsuarioPrintComponent } from './usuario-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: UsuarioPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  UsuarioPrintRoutingModule {

}