import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TipoDeUsuarioPrintComponent } from './tipodeusuario-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: TipoDeUsuarioPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  TipoDeUsuarioPrintRoutingModule {

}