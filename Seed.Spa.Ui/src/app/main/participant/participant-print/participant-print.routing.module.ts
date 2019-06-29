import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ParticipantPrintComponent } from './participant-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: ParticipantPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  ParticipantPrintRoutingModule {

}