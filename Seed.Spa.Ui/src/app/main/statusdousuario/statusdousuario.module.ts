import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { StatusDoUsuarioComponent } from './statusdousuario.component';

import { StatusDoUsuarioContainerFilterComponent } from './statusdousuario-container-filter/statusdousuario-container-filter.component';
import { StatusDoUsuarioFieldFilterComponent } from './statusdousuario-field-filter/statusdousuario-field-filter.component';

import { StatusDoUsuarioEditComponent } from './statusdousuario-edit/statusdousuario-edit.component';
import { StatusDoUsuarioCreateComponent } from './statusdousuario-create/statusdousuario-create.component';
import { StatusDoUsuarioDetailsComponent } from './statusdousuario-details/statusdousuario-details.component';

import { StatusDoUsuarioFieldCreateComponent } from './statusdousuario-field-create/statusdousuario-field-create.component';
import { StatusDoUsuarioFieldEditComponent } from './statusdousuario-field-edit/statusdousuario-field-edit.component';

import { StatusDoUsuarioContainerCreateComponent } from './statusdousuario-container-create/statusdousuario-container-create.component';
import { StatusDoUsuarioContainerEditComponent } from './statusdousuario-container-edit/statusdousuario-container-edit.component';

import { StatusDoUsuarioPrintModule } from './statusdousuario-print/statusdousuario-print.module';
import { StatusDoUsuarioRoutingModule } from './statusdousuario.routing.module';

import { StatusDoUsuarioService } from './statusdousuario.service';
import { StatusDoUsuarioServiceFields } from './statusdousuario.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        StatusDoUsuarioRoutingModule,
        StatusDoUsuarioPrintModule,

    ],
    declarations: [
        StatusDoUsuarioComponent,
        StatusDoUsuarioContainerFilterComponent,
        StatusDoUsuarioFieldFilterComponent,
        StatusDoUsuarioEditComponent,
        StatusDoUsuarioCreateComponent,
        StatusDoUsuarioDetailsComponent,
        StatusDoUsuarioFieldCreateComponent,
        StatusDoUsuarioFieldEditComponent,
        StatusDoUsuarioContainerCreateComponent,
        StatusDoUsuarioContainerEditComponent
    ],
    providers: [StatusDoUsuarioService,StatusDoUsuarioServiceFields, ApiService],
	exports: [StatusDoUsuarioComponent, StatusDoUsuarioEditComponent, StatusDoUsuarioCreateComponent]
})
export class StatusDoUsuarioModule {


}
