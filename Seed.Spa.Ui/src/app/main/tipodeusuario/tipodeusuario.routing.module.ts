import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TipoDeUsuarioComponent } from './tipodeusuario.component';
import { TipoDeUsuarioEditComponent } from './tipodeusuario-edit/tipodeusuario-edit.component';
import { TipoDeUsuarioDetailsComponent } from './tipodeusuario-details/tipodeusuario-details.component';
import { TipoDeUsuarioCreateComponent } from './tipodeusuario-create/tipodeusuario-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "TipoDeUsuario" }, component: TipoDeUsuarioComponent },
            { path: 'edit/:id', data : { title : "TipoDeUsuario" } ,component: TipoDeUsuarioEditComponent },
            { path: 'details/:id', data : { title : "TipoDeUsuario" }, component: TipoDeUsuarioDetailsComponent },
            { path: 'create', data : { title : "TipoDeUsuario" }, component: TipoDeUsuarioCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class TipoDeUsuarioRoutingModule {
}