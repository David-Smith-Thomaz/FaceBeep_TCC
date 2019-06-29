import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { GroupParticipantComponent } from './groupparticipant.component';
import { GroupParticipantEditComponent } from './groupparticipant-edit/groupparticipant-edit.component';
import { GroupParticipantDetailsComponent } from './groupparticipant-details/groupparticipant-details.component';
import { GroupParticipantCreateComponent } from './groupparticipant-create/groupparticipant-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "GroupParticipant" }, component: GroupParticipantComponent },
            { path: 'edit/:id', data : { title : "GroupParticipant" } ,component: GroupParticipantEditComponent },
            { path: 'details/:id', data : { title : "GroupParticipant" }, component: GroupParticipantDetailsComponent },
            { path: 'create', data : { title : "GroupParticipant" }, component: GroupParticipantCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class GroupParticipantRoutingModule {
}