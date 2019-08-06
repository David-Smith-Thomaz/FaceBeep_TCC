import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ParticipanteComponent } from './participante.component';
import { ParticipanteEditComponent } from './participante-edit/participante-edit.component';
import { ParticipanteDetailsComponent } from './participante-details/participante-details.component';
import { ParticipanteCreateComponent } from './participante-create/participante-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "Participante" }, component: ParticipanteComponent },
            { path: 'edit/:id', data : { title : "Participante" } ,component: ParticipanteEditComponent },
            { path: 'details/:id', data : { title : "Participante" }, component: ParticipanteDetailsComponent },
            { path: 'create', data : { title : "Participante" }, component: ParticipanteCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class ParticipanteRoutingModule {
}