import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TipoDeParticipanteComponent } from './tipodeparticipante.component';
import { TipoDeParticipanteEditComponent } from './tipodeparticipante-edit/tipodeparticipante-edit.component';
import { TipoDeParticipanteDetailsComponent } from './tipodeparticipante-details/tipodeparticipante-details.component';
import { TipoDeParticipanteCreateComponent } from './tipodeparticipante-create/tipodeparticipante-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "TipoDeParticipante" }, component: TipoDeParticipanteComponent },
            { path: 'edit/:id', data : { title : "TipoDeParticipante" } ,component: TipoDeParticipanteEditComponent },
            { path: 'details/:id', data : { title : "TipoDeParticipante" }, component: TipoDeParticipanteDetailsComponent },
            { path: 'create', data : { title : "TipoDeParticipante" }, component: TipoDeParticipanteCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class TipoDeParticipanteRoutingModule {
}