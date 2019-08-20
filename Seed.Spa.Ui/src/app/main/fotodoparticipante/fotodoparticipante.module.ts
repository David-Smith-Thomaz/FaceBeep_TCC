import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { FotoDoParticipanteComponent } from './fotodoparticipante.component';

import { FotoDoParticipanteContainerFilterComponent } from './fotodoparticipante-container-filter/fotodoparticipante-container-filter.component';
import { FotoDoParticipanteFieldFilterComponent } from './fotodoparticipante-field-filter/fotodoparticipante-field-filter.component';

import { FotoDoParticipanteEditComponent } from './fotodoparticipante-edit/fotodoparticipante-edit.component';
import { FotoDoParticipanteCreateComponent } from './fotodoparticipante-create/fotodoparticipante-create.component';
import { FotoDoParticipanteDetailsComponent } from './fotodoparticipante-details/fotodoparticipante-details.component';

import { FotoDoParticipanteFieldCreateComponent } from './fotodoparticipante-field-create/fotodoparticipante-field-create.component';
import { FotoDoParticipanteFieldEditComponent } from './fotodoparticipante-field-edit/fotodoparticipante-field-edit.component';

import { FotoDoParticipanteContainerCreateComponent } from './fotodoparticipante-container-create/fotodoparticipante-container-create.component';
import { FotoDoParticipanteContainerEditComponent } from './fotodoparticipante-container-edit/fotodoparticipante-container-edit.component';

import { FotoDoParticipantePrintModule } from './fotodoparticipante-print/fotodoparticipante-print.module';
import { FotoDoParticipanteRoutingModule } from './fotodoparticipante.routing.module';

import { FotoDoParticipanteService } from './fotodoparticipante.service';
import { FotoDoParticipanteServiceFields } from './fotodoparticipante.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        FotoDoParticipanteRoutingModule,
        FotoDoParticipantePrintModule,

    ],
    declarations: [
        FotoDoParticipanteComponent,
        FotoDoParticipanteContainerFilterComponent,
        FotoDoParticipanteFieldFilterComponent,
        FotoDoParticipanteEditComponent,
        FotoDoParticipanteCreateComponent,
        FotoDoParticipanteDetailsComponent,
        FotoDoParticipanteFieldCreateComponent,
        FotoDoParticipanteFieldEditComponent,
        FotoDoParticipanteContainerCreateComponent,
        FotoDoParticipanteContainerEditComponent
    ],
    providers: [FotoDoParticipanteService,FotoDoParticipanteServiceFields, ApiService],
	exports: [FotoDoParticipanteComponent, FotoDoParticipanteEditComponent, FotoDoParticipanteCreateComponent]
})
export class FotoDoParticipanteModule {


}
