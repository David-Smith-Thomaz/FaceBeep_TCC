import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TipoDeUsuarioPrintComponent } from './tipodeusuario-print.component';
import { TipoDeUsuarioPrintRoutingModule } from './tipodeusuario-print.routing.module';

import { TipoDeUsuarioService } from '../tipodeusuario.service';
import { ApiService } from '../../../common/services/api.service';
import { TipoDeUsuarioServiceFields } from '../tipodeusuario.service.fields';

import { TipoDeUsuarioContainerDetailsComponent } from '../tipodeusuario-container-details/tipodeusuario-container-details.component';
import { TipoDeUsuarioFieldDetailsComponent } from '../tipodeusuario-field-details/tipodeusuario-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        TipoDeUsuarioPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        TipoDeUsuarioPrintComponent,
        TipoDeUsuarioContainerDetailsComponent,
        TipoDeUsuarioFieldDetailsComponent
    ],
    providers: [TipoDeUsuarioService, ApiService, TipoDeUsuarioServiceFields],
    exports: [TipoDeUsuarioContainerDetailsComponent,TipoDeUsuarioFieldDetailsComponent]
})
export class TipoDeUsuarioPrintModule {

}
