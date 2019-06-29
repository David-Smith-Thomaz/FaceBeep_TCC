import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UserPrintComponent } from './user-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: UserPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  UserPrintRoutingModule {

}