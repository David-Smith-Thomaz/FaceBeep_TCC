import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusDoUsuarioComponent } from './statusdousuario.component';
import { StatusDoUsuarioEditComponent } from './statusdousuario-edit/statusdousuario-edit.component';
import { StatusDoUsuarioDetailsComponent } from './statusdousuario-details/statusdousuario-details.component';
import { StatusDoUsuarioCreateComponent } from './statusdousuario-create/statusdousuario-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "StatusDoUsuario" }, component: StatusDoUsuarioComponent },
            { path: 'edit/:id', data : { title : "StatusDoUsuario" } ,component: StatusDoUsuarioEditComponent },
            { path: 'details/:id', data : { title : "StatusDoUsuario" }, component: StatusDoUsuarioDetailsComponent },
            { path: 'create', data : { title : "StatusDoUsuario" }, component: StatusDoUsuarioCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class StatusDoUsuarioRoutingModule {
}