import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ParticipantePrintComponent } from './participante-print.component';
import { ParticipantePrintRoutingModule } from './participante-print.routing.module';

import { ParticipanteService } from '../participante.service';
import { ApiService } from '../../../common/services/api.service';
import { ParticipanteServiceFields } from '../participante.service.fields';

import { ParticipanteContainerDetailsComponent } from '../participante-container-details/participante-container-details.component';
import { ParticipanteFieldDetailsComponent } from '../participante-field-details/participante-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        ParticipantePrintRoutingModule,
        FormsModule
    ],
    declarations: [
        ParticipantePrintComponent,
        ParticipanteContainerDetailsComponent,
        ParticipanteFieldDetailsComponent
    ],
    providers: [ParticipanteService, ApiService, ParticipanteServiceFields],
    exports: [ParticipanteContainerDetailsComponent,ParticipanteFieldDetailsComponent]
})
export class ParticipantePrintModule {

}
