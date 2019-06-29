import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { GroupParticipantPrintComponent } from './groupparticipant-print.component';
import { GroupParticipantPrintRoutingModule } from './groupparticipant-print.routing.module';

import { GroupParticipantService } from '../groupparticipant.service';
import { ApiService } from '../../../common/services/api.service';
import { GroupParticipantServiceFields } from '../groupparticipant.service.fields';

import { GroupParticipantContainerDetailsComponent } from '../groupparticipant-container-details/groupparticipant-container-details.component';
import { GroupParticipantFieldDetailsComponent } from '../groupparticipant-field-details/groupparticipant-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        GroupParticipantPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        GroupParticipantPrintComponent,
        GroupParticipantContainerDetailsComponent,
        GroupParticipantFieldDetailsComponent
    ],
    providers: [GroupParticipantService, ApiService, GroupParticipantServiceFields],
    exports: [GroupParticipantContainerDetailsComponent,GroupParticipantFieldDetailsComponent]
})
export class GroupParticipantPrintModule {

}
