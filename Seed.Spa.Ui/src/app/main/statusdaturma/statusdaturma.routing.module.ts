import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusDaTurmaComponent } from './statusdaturma.component';
import { StatusDaTurmaEditComponent } from './statusdaturma-edit/statusdaturma-edit.component';
import { StatusDaTurmaDetailsComponent } from './statusdaturma-details/statusdaturma-details.component';
import { StatusDaTurmaCreateComponent } from './statusdaturma-create/statusdaturma-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "StatusDaTurma" }, component: StatusDaTurmaComponent },
            { path: 'edit/:id', data : { title : "StatusDaTurma" } ,component: StatusDaTurmaEditComponent },
            { path: 'details/:id', data : { title : "StatusDaTurma" }, component: StatusDaTurmaDetailsComponent },
            { path: 'create', data : { title : "StatusDaTurma" }, component: StatusDaTurmaCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class StatusDaTurmaRoutingModule {
}