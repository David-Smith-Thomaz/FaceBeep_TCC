import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { TipoDeUsuarioComponent } from './tipodeusuario.component';

import { TipoDeUsuarioContainerFilterComponent } from './tipodeusuario-container-filter/tipodeusuario-container-filter.component';
import { TipoDeUsuarioFieldFilterComponent } from './tipodeusuario-field-filter/tipodeusuario-field-filter.component';

import { TipoDeUsuarioEditComponent } from './tipodeusuario-edit/tipodeusuario-edit.component';
import { TipoDeUsuarioCreateComponent } from './tipodeusuario-create/tipodeusuario-create.component';
import { TipoDeUsuarioDetailsComponent } from './tipodeusuario-details/tipodeusuario-details.component';

import { TipoDeUsuarioFieldCreateComponent } from './tipodeusuario-field-create/tipodeusuario-field-create.component';
import { TipoDeUsuarioFieldEditComponent } from './tipodeusuario-field-edit/tipodeusuario-field-edit.component';

import { TipoDeUsuarioContainerCreateComponent } from './tipodeusuario-container-create/tipodeusuario-container-create.component';
import { TipoDeUsuarioContainerEditComponent } from './tipodeusuario-container-edit/tipodeusuario-container-edit.component';

import { TipoDeUsuarioPrintModule } from './tipodeusuario-print/tipodeusuario-print.module';
import { TipoDeUsuarioRoutingModule } from './tipodeusuario.routing.module';

import { TipoDeUsuarioService } from './tipodeusuario.service';
import { TipoDeUsuarioServiceFields } from './tipodeusuario.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        TipoDeUsuarioRoutingModule,
        TipoDeUsuarioPrintModule,

    ],
    declarations: [
        TipoDeUsuarioComponent,
        TipoDeUsuarioContainerFilterComponent,
        TipoDeUsuarioFieldFilterComponent,
        TipoDeUsuarioEditComponent,
        TipoDeUsuarioCreateComponent,
        TipoDeUsuarioDetailsComponent,
        TipoDeUsuarioFieldCreateComponent,
        TipoDeUsuarioFieldEditComponent,
        TipoDeUsuarioContainerCreateComponent,
        TipoDeUsuarioContainerEditComponent
    ],
    providers: [TipoDeUsuarioService,TipoDeUsuarioServiceFields, ApiService],
	exports: [TipoDeUsuarioComponent, TipoDeUsuarioEditComponent, TipoDeUsuarioCreateComponent]
})
export class TipoDeUsuarioModule {


}
