import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FotoDoParticipantePrintComponent } from './fotodoparticipante-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: FotoDoParticipantePrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  FotoDoParticipantePrintRoutingModule {

}