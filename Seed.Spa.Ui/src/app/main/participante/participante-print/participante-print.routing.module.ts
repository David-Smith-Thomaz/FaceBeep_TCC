import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ParticipantePrintComponent } from './participante-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: ParticipantePrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  ParticipantePrintRoutingModule {

}