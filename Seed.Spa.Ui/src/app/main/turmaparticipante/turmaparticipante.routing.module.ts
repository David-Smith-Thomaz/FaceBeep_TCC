import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TurmaParticipanteComponent } from './turmaparticipante.component';
import { TurmaParticipanteEditComponent } from './turmaparticipante-edit/turmaparticipante-edit.component';
import { TurmaParticipanteDetailsComponent } from './turmaparticipante-details/turmaparticipante-details.component';
import { TurmaParticipanteCreateComponent } from './turmaparticipante-create/turmaparticipante-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "TurmaParticipante" }, component: TurmaParticipanteComponent },
            { path: 'edit/:id', data : { title : "TurmaParticipante" } ,component: TurmaParticipanteEditComponent },
            { path: 'details/:id', data : { title : "TurmaParticipante" }, component: TurmaParticipanteDetailsComponent },
            { path: 'create', data : { title : "TurmaParticipante" }, component: TurmaParticipanteCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class TurmaParticipanteRoutingModule {
}