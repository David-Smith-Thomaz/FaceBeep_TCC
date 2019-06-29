import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ParticipantPrintComponent } from './participant-print.component';
import { ParticipantPrintRoutingModule } from './participant-print.routing.module';

import { ParticipantService } from '../participant.service';
import { ApiService } from '../../../common/services/api.service';
import { ParticipantServiceFields } from '../participant.service.fields';

import { ParticipantContainerDetailsComponent } from '../participant-container-details/participant-container-details.component';
import { ParticipantFieldDetailsComponent } from '../participant-field-details/participant-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        ParticipantPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        ParticipantPrintComponent,
        ParticipantContainerDetailsComponent,
        ParticipantFieldDetailsComponent
    ],
    providers: [ParticipantService, ApiService, ParticipantServiceFields],
    exports: [ParticipantContainerDetailsComponent,ParticipantFieldDetailsComponent]
})
export class ParticipantPrintModule {

}
