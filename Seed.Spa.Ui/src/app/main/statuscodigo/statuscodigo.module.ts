import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { StatusCodigoComponent } from './statuscodigo.component';

import { StatusCodigoContainerFilterComponent } from './statuscodigo-container-filter/statuscodigo-container-filter.component';
import { StatusCodigoFieldFilterComponent } from './statuscodigo-field-filter/statuscodigo-field-filter.component';

import { StatusCodigoEditComponent } from './statuscodigo-edit/statuscodigo-edit.component';
import { StatusCodigoCreateComponent } from './statuscodigo-create/statuscodigo-create.component';
import { StatusCodigoDetailsComponent } from './statuscodigo-details/statuscodigo-details.component';

import { StatusCodigoFieldCreateComponent } from './statuscodigo-field-create/statuscodigo-field-create.component';
import { StatusCodigoFieldEditComponent } from './statuscodigo-field-edit/statuscodigo-field-edit.component';

import { StatusCodigoContainerCreateComponent } from './statuscodigo-container-create/statuscodigo-container-create.component';
import { StatusCodigoContainerEditComponent } from './statuscodigo-container-edit/statuscodigo-container-edit.component';

import { StatusCodigoPrintModule } from './statuscodigo-print/statuscodigo-print.module';
import { StatusCodigoRoutingModule } from './statuscodigo.routing.module';

import { StatusCodigoService } from './statuscodigo.service';
import { StatusCodigoServiceFields } from './statuscodigo.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        StatusCodigoRoutingModule,
        StatusCodigoPrintModule,

    ],
    declarations: [
        StatusCodigoComponent,
        StatusCodigoContainerFilterComponent,
        StatusCodigoFieldFilterComponent,
        StatusCodigoEditComponent,
        StatusCodigoCreateComponent,
        StatusCodigoDetailsComponent,
        StatusCodigoFieldCreateComponent,
        StatusCodigoFieldEditComponent,
        StatusCodigoContainerCreateComponent,
        StatusCodigoContainerEditComponent
    ],
    providers: [StatusCodigoService,StatusCodigoServiceFields, ApiService],
	exports: [StatusCodigoComponent, StatusCodigoEditComponent, StatusCodigoCreateComponent]
})
export class StatusCodigoModule {


}
