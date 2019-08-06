import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { TurmaParticipanteComponent } from './turmaparticipante.component';

import { TurmaParticipanteContainerFilterComponent } from './turmaparticipante-container-filter/turmaparticipante-container-filter.component';
import { TurmaParticipanteFieldFilterComponent } from './turmaparticipante-field-filter/turmaparticipante-field-filter.component';

import { TurmaParticipanteEditComponent } from './turmaparticipante-edit/turmaparticipante-edit.component';
import { TurmaParticipanteCreateComponent } from './turmaparticipante-create/turmaparticipante-create.component';
import { TurmaParticipanteDetailsComponent } from './turmaparticipante-details/turmaparticipante-details.component';

import { TurmaParticipanteFieldCreateComponent } from './turmaparticipante-field-create/turmaparticipante-field-create.component';
import { TurmaParticipanteFieldEditComponent } from './turmaparticipante-field-edit/turmaparticipante-field-edit.component';

import { TurmaParticipanteContainerCreateComponent } from './turmaparticipante-container-create/turmaparticipante-container-create.component';
import { TurmaParticipanteContainerEditComponent } from './turmaparticipante-container-edit/turmaparticipante-container-edit.component';

import { TurmaParticipantePrintModule } from './turmaparticipante-print/turmaparticipante-print.module';
import { TurmaParticipanteRoutingModule } from './turmaparticipante.routing.module';

import { TurmaParticipanteService } from './turmaparticipante.service';
import { TurmaParticipanteServiceFields } from './turmaparticipante.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        TurmaParticipanteRoutingModule,
        TurmaParticipantePrintModule,

    ],
    declarations: [
        TurmaParticipanteComponent,
        TurmaParticipanteContainerFilterComponent,
        TurmaParticipanteFieldFilterComponent,
        TurmaParticipanteEditComponent,
        TurmaParticipanteCreateComponent,
        TurmaParticipanteDetailsComponent,
        TurmaParticipanteFieldCreateComponent,
        TurmaParticipanteFieldEditComponent,
        TurmaParticipanteContainerCreateComponent,
        TurmaParticipanteContainerEditComponent
    ],
    providers: [TurmaParticipanteService,TurmaParticipanteServiceFields, ApiService],
	exports: [TurmaParticipanteComponent, TurmaParticipanteEditComponent, TurmaParticipanteCreateComponent]
})
export class TurmaParticipanteModule {


}
