import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CodigoVerificacaoPrintComponent } from './codigoverificacao-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: CodigoVerificacaoPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  CodigoVerificacaoPrintRoutingModule {

}