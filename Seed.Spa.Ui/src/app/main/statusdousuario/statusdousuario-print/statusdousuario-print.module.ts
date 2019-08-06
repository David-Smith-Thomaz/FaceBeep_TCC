import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StatusDoUsuarioPrintComponent } from './statusdousuario-print.component';
import { StatusDoUsuarioPrintRoutingModule } from './statusdousuario-print.routing.module';

import { StatusDoUsuarioService } from '../statusdousuario.service';
import { ApiService } from '../../../common/services/api.service';
import { StatusDoUsuarioServiceFields } from '../statusdousuario.service.fields';

import { StatusDoUsuarioContainerDetailsComponent } from '../statusdousuario-container-details/statusdousuario-container-details.component';
import { StatusDoUsuarioFieldDetailsComponent } from '../statusdousuario-field-details/statusdousuario-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        StatusDoUsuarioPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        StatusDoUsuarioPrintComponent,
        StatusDoUsuarioContainerDetailsComponent,
        StatusDoUsuarioFieldDetailsComponent
    ],
    providers: [StatusDoUsuarioService, ApiService, StatusDoUsuarioServiceFields],
    exports: [StatusDoUsuarioContainerDetailsComponent,StatusDoUsuarioFieldDetailsComponent]
})
export class StatusDoUsuarioPrintModule {

}
