import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UsuarioComponent } from './usuario.component';
import { UsuarioEditComponent } from './usuario-edit/usuario-edit.component';
import { UsuarioDetailsComponent } from './usuario-details/usuario-details.component';
import { UsuarioCreateComponent } from './usuario-create/usuario-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "Usuario" }, component: UsuarioComponent },
            { path: 'edit/:id', data : { title : "Usuario" } ,component: UsuarioEditComponent },
            { path: 'details/:id', data : { title : "Usuario" }, component: UsuarioDetailsComponent },
            { path: 'create', data : { title : "Usuario" }, component: UsuarioCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class UsuarioRoutingModule {
}