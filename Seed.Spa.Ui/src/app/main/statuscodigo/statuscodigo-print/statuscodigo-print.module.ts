import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StatusCodigoPrintComponent } from './statuscodigo-print.component';
import { StatusCodigoPrintRoutingModule } from './statuscodigo-print.routing.module';

import { StatusCodigoService } from '../statuscodigo.service';
import { ApiService } from '../../../common/services/api.service';
import { StatusCodigoServiceFields } from '../statuscodigo.service.fields';

import { StatusCodigoContainerDetailsComponent } from '../statuscodigo-container-details/statuscodigo-container-details.component';
import { StatusCodigoFieldDetailsComponent } from '../statuscodigo-field-details/statuscodigo-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        StatusCodigoPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        StatusCodigoPrintComponent,
        StatusCodigoContainerDetailsComponent,
        StatusCodigoFieldDetailsComponent
    ],
    providers: [StatusCodigoService, ApiService, StatusCodigoServiceFields],
    exports: [StatusCodigoContainerDetailsComponent,StatusCodigoFieldDetailsComponent]
})
export class StatusCodigoPrintModule {

}
