import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { StatusRegisterComponent } from './statusregister.component';

import { StatusRegisterContainerFilterComponent } from './statusregister-container-filter/statusregister-container-filter.component';
import { StatusRegisterFieldFilterComponent } from './statusregister-field-filter/statusregister-field-filter.component';

import { StatusRegisterEditComponent } from './statusregister-edit/statusregister-edit.component';
import { StatusRegisterCreateComponent } from './statusregister-create/statusregister-create.component';
import { StatusRegisterDetailsComponent } from './statusregister-details/statusregister-details.component';

import { StatusRegisterFieldCreateComponent } from './statusregister-field-create/statusregister-field-create.component';
import { StatusRegisterFieldEditComponent } from './statusregister-field-edit/statusregister-field-edit.component';

import { StatusRegisterContainerCreateComponent } from './statusregister-container-create/statusregister-container-create.component';
import { StatusRegisterContainerEditComponent } from './statusregister-container-edit/statusregister-container-edit.component';

import { StatusRegisterPrintModule } from './statusregister-print/statusregister-print.module';
import { StatusRegisterRoutingModule } from './statusregister.routing.module';

import { StatusRegisterService } from './statusregister.service';
import { StatusRegisterServiceFields } from './statusregister.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        StatusRegisterRoutingModule,
        StatusRegisterPrintModule,

    ],
    declarations: [
        StatusRegisterComponent,
        StatusRegisterContainerFilterComponent,
        StatusRegisterFieldFilterComponent,
        StatusRegisterEditComponent,
        StatusRegisterCreateComponent,
        StatusRegisterDetailsComponent,
        StatusRegisterFieldCreateComponent,
        StatusRegisterFieldEditComponent,
        StatusRegisterContainerCreateComponent,
        StatusRegisterContainerEditComponent
    ],
    providers: [StatusRegisterService,StatusRegisterServiceFields, ApiService],
	exports: [StatusRegisterComponent, StatusRegisterEditComponent, StatusRegisterCreateComponent]
})
export class StatusRegisterModule {


}
