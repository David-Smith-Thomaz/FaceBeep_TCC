import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { TipoDeParticipanteComponent } from './tipodeparticipante.component';

import { TipoDeParticipanteContainerFilterComponent } from './tipodeparticipante-container-filter/tipodeparticipante-container-filter.component';
import { TipoDeParticipanteFieldFilterComponent } from './tipodeparticipante-field-filter/tipodeparticipante-field-filter.component';

import { TipoDeParticipanteEditComponent } from './tipodeparticipante-edit/tipodeparticipante-edit.component';
import { TipoDeParticipanteCreateComponent } from './tipodeparticipante-create/tipodeparticipante-create.component';
import { TipoDeParticipanteDetailsComponent } from './tipodeparticipante-details/tipodeparticipante-details.component';

import { TipoDeParticipanteFieldCreateComponent } from './tipodeparticipante-field-create/tipodeparticipante-field-create.component';
import { TipoDeParticipanteFieldEditComponent } from './tipodeparticipante-field-edit/tipodeparticipante-field-edit.component';

import { TipoDeParticipanteContainerCreateComponent } from './tipodeparticipante-container-create/tipodeparticipante-container-create.component';
import { TipoDeParticipanteContainerEditComponent } from './tipodeparticipante-container-edit/tipodeparticipante-container-edit.component';

import { TipoDeParticipantePrintModule } from './tipodeparticipante-print/tipodeparticipante-print.module';
import { TipoDeParticipanteRoutingModule } from './tipodeparticipante.routing.module';

import { TipoDeParticipanteService } from './tipodeparticipante.service';
import { TipoDeParticipanteServiceFields } from './tipodeparticipante.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        TipoDeParticipanteRoutingModule,
        TipoDeParticipantePrintModule,

    ],
    declarations: [
        TipoDeParticipanteComponent,
        TipoDeParticipanteContainerFilterComponent,
        TipoDeParticipanteFieldFilterComponent,
        TipoDeParticipanteEditComponent,
        TipoDeParticipanteCreateComponent,
        TipoDeParticipanteDetailsComponent,
        TipoDeParticipanteFieldCreateComponent,
        TipoDeParticipanteFieldEditComponent,
        TipoDeParticipanteContainerCreateComponent,
        TipoDeParticipanteContainerEditComponent
    ],
    providers: [TipoDeParticipanteService,TipoDeParticipanteServiceFields, ApiService],
	exports: [TipoDeParticipanteComponent, TipoDeParticipanteEditComponent, TipoDeParticipanteCreateComponent]
})
export class TipoDeParticipanteModule {


}
