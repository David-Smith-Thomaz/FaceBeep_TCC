import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { CodigoVerificacaoComponent } from './codigoverificacao.component';

import { CodigoVerificacaoContainerFilterComponent } from './codigoverificacao-container-filter/codigoverificacao-container-filter.component';
import { CodigoVerificacaoFieldFilterComponent } from './codigoverificacao-field-filter/codigoverificacao-field-filter.component';

import { CodigoVerificacaoEditComponent } from './codigoverificacao-edit/codigoverificacao-edit.component';
import { CodigoVerificacaoCreateComponent } from './codigoverificacao-create/codigoverificacao-create.component';
import { CodigoVerificacaoDetailsComponent } from './codigoverificacao-details/codigoverificacao-details.component';

import { CodigoVerificacaoFieldCreateComponent } from './codigoverificacao-field-create/codigoverificacao-field-create.component';
import { CodigoVerificacaoFieldEditComponent } from './codigoverificacao-field-edit/codigoverificacao-field-edit.component';

import { CodigoVerificacaoContainerCreateComponent } from './codigoverificacao-container-create/codigoverificacao-container-create.component';
import { CodigoVerificacaoContainerEditComponent } from './codigoverificacao-container-edit/codigoverificacao-container-edit.component';

import { CodigoVerificacaoPrintModule } from './codigoverificacao-print/codigoverificacao-print.module';
import { CodigoVerificacaoRoutingModule } from './codigoverificacao.routing.module';

import { CodigoVerificacaoService } from './codigoverificacao.service';
import { CodigoVerificacaoServiceFields } from './codigoverificacao.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        CodigoVerificacaoRoutingModule,
        CodigoVerificacaoPrintModule,

    ],
    declarations: [
        CodigoVerificacaoComponent,
        CodigoVerificacaoContainerFilterComponent,
        CodigoVerificacaoFieldFilterComponent,
        CodigoVerificacaoEditComponent,
        CodigoVerificacaoCreateComponent,
        CodigoVerificacaoDetailsComponent,
        CodigoVerificacaoFieldCreateComponent,
        CodigoVerificacaoFieldEditComponent,
        CodigoVerificacaoContainerCreateComponent,
        CodigoVerificacaoContainerEditComponent
    ],
    providers: [CodigoVerificacaoService,CodigoVerificacaoServiceFields, ApiService],
	exports: [CodigoVerificacaoComponent, CodigoVerificacaoEditComponent, CodigoVerificacaoCreateComponent]
})
export class CodigoVerificacaoModule {


}
