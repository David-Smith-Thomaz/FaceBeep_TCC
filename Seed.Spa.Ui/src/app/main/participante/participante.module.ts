import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { ParticipanteComponent } from './participante.component';

import { ParticipanteContainerFilterComponent } from './participante-container-filter/participante-container-filter.component';
import { ParticipanteFieldFilterComponent } from './participante-field-filter/participante-field-filter.component';

import { ParticipanteEditComponent } from './participante-edit/participante-edit.component';
import { ParticipanteCreateComponent } from './participante-create/participante-create.component';
import { ParticipanteDetailsComponent } from './participante-details/participante-details.component';

import { ParticipanteFieldCreateComponent } from './participante-field-create/participante-field-create.component';
import { ParticipanteFieldEditComponent } from './participante-field-edit/participante-field-edit.component';

import { ParticipanteContainerCreateComponent } from './participante-container-create/participante-container-create.component';
import { ParticipanteContainerEditComponent } from './participante-container-edit/participante-container-edit.component';

import { ParticipantePrintModule } from './participante-print/participante-print.module';
import { ParticipanteRoutingModule } from './participante.routing.module';

import { ParticipanteService } from './participante.service';
import { ParticipanteServiceFields } from './participante.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        ParticipanteRoutingModule,
        ParticipantePrintModule,

    ],
    declarations: [
        ParticipanteComponent,
        ParticipanteContainerFilterComponent,
        ParticipanteFieldFilterComponent,
        ParticipanteEditComponent,
        ParticipanteCreateComponent,
        ParticipanteDetailsComponent,
        ParticipanteFieldCreateComponent,
        ParticipanteFieldEditComponent,
        ParticipanteContainerCreateComponent,
        ParticipanteContainerEditComponent
    ],
    providers: [ParticipanteService,ParticipanteServiceFields, ApiService],
	exports: [ParticipanteComponent, ParticipanteEditComponent, ParticipanteCreateComponent]
})
export class ParticipanteModule {


}
