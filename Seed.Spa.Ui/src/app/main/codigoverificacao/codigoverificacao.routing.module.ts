import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CodigoVerificacaoComponent } from './codigoverificacao.component';
import { CodigoVerificacaoEditComponent } from './codigoverificacao-edit/codigoverificacao-edit.component';
import { CodigoVerificacaoDetailsComponent } from './codigoverificacao-details/codigoverificacao-details.component';
import { CodigoVerificacaoCreateComponent } from './codigoverificacao-create/codigoverificacao-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "CodigoVerificacao" }, component: CodigoVerificacaoComponent },
            { path: 'edit/:id', data : { title : "CodigoVerificacao" } ,component: CodigoVerificacaoEditComponent },
            { path: 'details/:id', data : { title : "CodigoVerificacao" }, component: CodigoVerificacaoDetailsComponent },
            { path: 'create', data : { title : "CodigoVerificacao" }, component: CodigoVerificacaoCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class CodigoVerificacaoRoutingModule {
}