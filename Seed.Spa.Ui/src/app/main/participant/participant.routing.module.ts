import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ParticipantComponent } from './participant.component';
import { ParticipantEditComponent } from './participant-edit/participant-edit.component';
import { ParticipantDetailsComponent } from './participant-details/participant-details.component';
import { ParticipantCreateComponent } from './participant-create/participant-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "Participant" }, component: ParticipantComponent },
            { path: 'edit/:id', data : { title : "Participant" } ,component: ParticipantEditComponent },
            { path: 'details/:id', data : { title : "Participant" }, component: ParticipantDetailsComponent },
            { path: 'create', data : { title : "Participant" }, component: ParticipantCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class ParticipantRoutingModule {
}