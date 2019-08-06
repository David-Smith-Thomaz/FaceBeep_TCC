import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { UsuarioComponent } from './usuario.component';

import { UsuarioContainerFilterComponent } from './usuario-container-filter/usuario-container-filter.component';
import { UsuarioFieldFilterComponent } from './usuario-field-filter/usuario-field-filter.component';

import { UsuarioEditComponent } from './usuario-edit/usuario-edit.component';
import { UsuarioCreateComponent } from './usuario-create/usuario-create.component';
import { UsuarioDetailsComponent } from './usuario-details/usuario-details.component';

import { UsuarioFieldCreateComponent } from './usuario-field-create/usuario-field-create.component';
import { UsuarioFieldEditComponent } from './usuario-field-edit/usuario-field-edit.component';

import { UsuarioContainerCreateComponent } from './usuario-container-create/usuario-container-create.component';
import { UsuarioContainerEditComponent } from './usuario-container-edit/usuario-container-edit.component';

import { UsuarioPrintModule } from './usuario-print/usuario-print.module';
import { UsuarioRoutingModule } from './usuario.routing.module';

import { UsuarioService } from './usuario.service';
import { UsuarioServiceFields } from './usuario.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        UsuarioRoutingModule,
        UsuarioPrintModule,

    ],
    declarations: [
        UsuarioComponent,
        UsuarioContainerFilterComponent,
        UsuarioFieldFilterComponent,
        UsuarioEditComponent,
        UsuarioCreateComponent,
        UsuarioDetailsComponent,
        UsuarioFieldCreateComponent,
        UsuarioFieldEditComponent,
        UsuarioContainerCreateComponent,
        UsuarioContainerEditComponent
    ],
    providers: [UsuarioService,UsuarioServiceFields, ApiService],
	exports: [UsuarioComponent, UsuarioEditComponent, UsuarioCreateComponent]
})
export class UsuarioModule {


}
