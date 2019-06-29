import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { GroupParticipantComponent } from './groupparticipant.component';

import { GroupParticipantContainerFilterComponent } from './groupparticipant-container-filter/groupparticipant-container-filter.component';
import { GroupParticipantFieldFilterComponent } from './groupparticipant-field-filter/groupparticipant-field-filter.component';

import { GroupParticipantEditComponent } from './groupparticipant-edit/groupparticipant-edit.component';
import { GroupParticipantCreateComponent } from './groupparticipant-create/groupparticipant-create.component';
import { GroupParticipantDetailsComponent } from './groupparticipant-details/groupparticipant-details.component';

import { GroupParticipantFieldCreateComponent } from './groupparticipant-field-create/groupparticipant-field-create.component';
import { GroupParticipantFieldEditComponent } from './groupparticipant-field-edit/groupparticipant-field-edit.component';

import { GroupParticipantContainerCreateComponent } from './groupparticipant-container-create/groupparticipant-container-create.component';
import { GroupParticipantContainerEditComponent } from './groupparticipant-container-edit/groupparticipant-container-edit.component';

import { GroupParticipantPrintModule } from './groupparticipant-print/groupparticipant-print.module';
import { GroupParticipantRoutingModule } from './groupparticipant.routing.module';

import { GroupParticipantService } from './groupparticipant.service';
import { GroupParticipantServiceFields } from './groupparticipant.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        GroupParticipantRoutingModule,
        GroupParticipantPrintModule,

    ],
    declarations: [
        GroupParticipantComponent,
        GroupParticipantContainerFilterComponent,
        GroupParticipantFieldFilterComponent,
        GroupParticipantEditComponent,
        GroupParticipantCreateComponent,
        GroupParticipantDetailsComponent,
        GroupParticipantFieldCreateComponent,
        GroupParticipantFieldEditComponent,
        GroupParticipantContainerCreateComponent,
        GroupParticipantContainerEditComponent
    ],
    providers: [GroupParticipantService,GroupParticipantServiceFields, ApiService],
	exports: [GroupParticipantComponent, GroupParticipantEditComponent, GroupParticipantCreateComponent]
})
export class GroupParticipantModule {


}
