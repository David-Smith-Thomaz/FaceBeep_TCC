import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { ParticipantComponent } from './participant.component';

import { ParticipantContainerFilterComponent } from './participant-container-filter/participant-container-filter.component';
import { ParticipantFieldFilterComponent } from './participant-field-filter/participant-field-filter.component';

import { ParticipantEditComponent } from './participant-edit/participant-edit.component';
import { ParticipantCreateComponent } from './participant-create/participant-create.component';
import { ParticipantDetailsComponent } from './participant-details/participant-details.component';

import { ParticipantFieldCreateComponent } from './participant-field-create/participant-field-create.component';
import { ParticipantFieldEditComponent } from './participant-field-edit/participant-field-edit.component';

import { ParticipantContainerCreateComponent } from './participant-container-create/participant-container-create.component';
import { ParticipantContainerEditComponent } from './participant-container-edit/participant-container-edit.component';

import { ParticipantPrintModule } from './participant-print/participant-print.module';
import { ParticipantRoutingModule } from './participant.routing.module';

import { ParticipantService } from './participant.service';
import { ParticipantServiceFields } from './participant.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        ParticipantRoutingModule,
        ParticipantPrintModule,

    ],
    declarations: [
        ParticipantComponent,
        ParticipantContainerFilterComponent,
        ParticipantFieldFilterComponent,
        ParticipantEditComponent,
        ParticipantCreateComponent,
        ParticipantDetailsComponent,
        ParticipantFieldCreateComponent,
        ParticipantFieldEditComponent,
        ParticipantContainerCreateComponent,
        ParticipantContainerEditComponent
    ],
    providers: [ParticipantService,ParticipantServiceFields, ApiService],
	exports: [ParticipantComponent, ParticipantEditComponent, ParticipantCreateComponent]
})
export class ParticipantModule {


}
