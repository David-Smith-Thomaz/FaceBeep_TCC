import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TipoDeParticipantePrintComponent } from './tipodeparticipante-print.component';
import { TipoDeParticipantePrintRoutingModule } from './tipodeparticipante-print.routing.module';

import { TipoDeParticipanteService } from '../tipodeparticipante.service';
import { ApiService } from '../../../common/services/api.service';
import { TipoDeParticipanteServiceFields } from '../tipodeparticipante.service.fields';

import { TipoDeParticipanteContainerDetailsComponent } from '../tipodeparticipante-container-details/tipodeparticipante-container-details.component';
import { TipoDeParticipanteFieldDetailsComponent } from '../tipodeparticipante-field-details/tipodeparticipante-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        TipoDeParticipantePrintRoutingModule,
        FormsModule
    ],
    declarations: [
        TipoDeParticipantePrintComponent,
        TipoDeParticipanteContainerDetailsComponent,
        TipoDeParticipanteFieldDetailsComponent
    ],
    providers: [TipoDeParticipanteService, ApiService, TipoDeParticipanteServiceFields],
    exports: [TipoDeParticipanteContainerDetailsComponent,TipoDeParticipanteFieldDetailsComponent]
})
export class TipoDeParticipantePrintModule {

}
