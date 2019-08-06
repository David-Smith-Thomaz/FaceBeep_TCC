import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TurmaParticipantePrintComponent } from './turmaparticipante-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: TurmaParticipantePrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  TurmaParticipantePrintRoutingModule {

}