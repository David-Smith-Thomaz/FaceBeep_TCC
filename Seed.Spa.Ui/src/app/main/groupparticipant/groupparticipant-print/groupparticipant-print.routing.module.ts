import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { GroupParticipantPrintComponent } from './groupparticipant-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: GroupParticipantPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  GroupParticipantPrintRoutingModule {

}