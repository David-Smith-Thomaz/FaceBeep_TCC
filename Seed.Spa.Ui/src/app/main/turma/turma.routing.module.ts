import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TurmaComponent } from './turma.component';
import { TurmaEditComponent } from './turma-edit/turma-edit.component';
import { TurmaDetailsComponent } from './turma-details/turma-details.component';
import { TurmaCreateComponent } from './turma-create/turma-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "Turma" }, component: TurmaComponent },
            { path: 'edit/:id', data : { title : "Turma" } ,component: TurmaEditComponent },
            { path: 'details/:id', data : { title : "Turma" }, component: TurmaDetailsComponent },
            { path: 'create', data : { title : "Turma" }, component: TurmaCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class TurmaRoutingModule {
}