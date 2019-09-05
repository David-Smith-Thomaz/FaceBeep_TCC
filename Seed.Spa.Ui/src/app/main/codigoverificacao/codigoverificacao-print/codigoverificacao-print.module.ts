import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CodigoVerificacaoPrintComponent } from './codigoverificacao-print.component';
import { CodigoVerificacaoPrintRoutingModule } from './codigoverificacao-print.routing.module';

import { CodigoVerificacaoService } from '../codigoverificacao.service';
import { ApiService } from '../../../common/services/api.service';
import { CodigoVerificacaoServiceFields } from '../codigoverificacao.service.fields';

import { CodigoVerificacaoContainerDetailsComponent } from '../codigoverificacao-container-details/codigoverificacao-container-details.component';
import { CodigoVerificacaoFieldDetailsComponent } from '../codigoverificacao-field-details/codigoverificacao-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        CodigoVerificacaoPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        CodigoVerificacaoPrintComponent,
        CodigoVerificacaoContainerDetailsComponent,
        CodigoVerificacaoFieldDetailsComponent
    ],
    providers: [CodigoVerificacaoService, ApiService, CodigoVerificacaoServiceFields],
    exports: [CodigoVerificacaoContainerDetailsComponent,CodigoVerificacaoFieldDetailsComponent]
})
export class CodigoVerificacaoPrintModule {

}
