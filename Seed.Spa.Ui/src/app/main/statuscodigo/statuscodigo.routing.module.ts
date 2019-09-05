import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusCodigoComponent } from './statuscodigo.component';
import { StatusCodigoEditComponent } from './statuscodigo-edit/statuscodigo-edit.component';
import { StatusCodigoDetailsComponent } from './statuscodigo-details/statuscodigo-details.component';
import { StatusCodigoCreateComponent } from './statuscodigo-create/statuscodigo-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "StatusCodigo" }, component: StatusCodigoComponent },
            { path: 'edit/:id', data : { title : "StatusCodigo" } ,component: StatusCodigoEditComponent },
            { path: 'details/:id', data : { title : "StatusCodigo" }, component: StatusCodigoDetailsComponent },
            { path: 'create', data : { title : "StatusCodigo" }, component: StatusCodigoCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class StatusCodigoRoutingModule {
}