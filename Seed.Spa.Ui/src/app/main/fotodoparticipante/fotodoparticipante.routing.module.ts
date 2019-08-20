import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FotoDoParticipanteComponent } from './fotodoparticipante.component';
import { FotoDoParticipanteEditComponent } from './fotodoparticipante-edit/fotodoparticipante-edit.component';
import { FotoDoParticipanteDetailsComponent } from './fotodoparticipante-details/fotodoparticipante-details.component';
import { FotoDoParticipanteCreateComponent } from './fotodoparticipante-create/fotodoparticipante-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "FotoDoParticipante" }, component: FotoDoParticipanteComponent },
            { path: 'edit/:id', data : { title : "FotoDoParticipante" } ,component: FotoDoParticipanteEditComponent },
            { path: 'details/:id', data : { title : "FotoDoParticipante" }, component: FotoDoParticipanteDetailsComponent },
            { path: 'create', data : { title : "FotoDoParticipante" }, component: FotoDoParticipanteCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class FotoDoParticipanteRoutingModule {
}