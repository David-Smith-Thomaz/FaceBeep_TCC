import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TipoDeParticipantePrintComponent } from './tipodeparticipante-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: TipoDeParticipantePrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  TipoDeParticipantePrintRoutingModule {

}