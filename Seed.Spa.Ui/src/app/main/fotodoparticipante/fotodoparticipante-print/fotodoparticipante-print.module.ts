import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FotoDoParticipantePrintComponent } from './fotodoparticipante-print.component';
import { FotoDoParticipantePrintRoutingModule } from './fotodoparticipante-print.routing.module';

import { FotoDoParticipanteService } from '../fotodoparticipante.service';
import { ApiService } from '../../../common/services/api.service';
import { FotoDoParticipanteServiceFields } from '../fotodoparticipante.service.fields';

import { FotoDoParticipanteContainerDetailsComponent } from '../fotodoparticipante-container-details/fotodoparticipante-container-details.component';
import { FotoDoParticipanteFieldDetailsComponent } from '../fotodoparticipante-field-details/fotodoparticipante-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        FotoDoParticipantePrintRoutingModule,
        FormsModule
    ],
    declarations: [
        FotoDoParticipantePrintComponent,
        FotoDoParticipanteContainerDetailsComponent,
        FotoDoParticipanteFieldDetailsComponent
    ],
    providers: [FotoDoParticipanteService, ApiService, FotoDoParticipanteServiceFields],
    exports: [FotoDoParticipanteContainerDetailsComponent,FotoDoParticipanteFieldDetailsComponent]
})
export class FotoDoParticipantePrintModule {

}
