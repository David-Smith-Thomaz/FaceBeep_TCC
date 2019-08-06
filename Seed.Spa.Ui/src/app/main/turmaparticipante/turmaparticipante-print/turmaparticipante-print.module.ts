import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TurmaParticipantePrintComponent } from './turmaparticipante-print.component';
import { TurmaParticipantePrintRoutingModule } from './turmaparticipante-print.routing.module';

import { TurmaParticipanteService } from '../turmaparticipante.service';
import { ApiService } from '../../../common/services/api.service';
import { TurmaParticipanteServiceFields } from '../turmaparticipante.service.fields';

import { TurmaParticipanteContainerDetailsComponent } from '../turmaparticipante-container-details/turmaparticipante-container-details.component';
import { TurmaParticipanteFieldDetailsComponent } from '../turmaparticipante-field-details/turmaparticipante-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        TurmaParticipantePrintRoutingModule,
        FormsModule
    ],
    declarations: [
        TurmaParticipantePrintComponent,
        TurmaParticipanteContainerDetailsComponent,
        TurmaParticipanteFieldDetailsComponent
    ],
    providers: [TurmaParticipanteService, ApiService, TurmaParticipanteServiceFields],
    exports: [TurmaParticipanteContainerDetailsComponent,TurmaParticipanteFieldDetailsComponent]
})
export class TurmaParticipantePrintModule {

}
