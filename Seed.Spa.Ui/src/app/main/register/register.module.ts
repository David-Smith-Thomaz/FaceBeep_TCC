import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { RegisterComponent } from './register.component';

import { RegisterContainerFilterComponent } from './register-container-filter/register-container-filter.component';
import { RegisterFieldFilterComponent } from './register-field-filter/register-field-filter.component';

import { RegisterEditComponent } from './register-edit/register-edit.component';
import { RegisterCreateComponent } from './register-create/register-create.component';
import { RegisterDetailsComponent } from './register-details/register-details.component';

import { RegisterFieldCreateComponent } from './register-field-create/register-field-create.component';
import { RegisterFieldEditComponent } from './register-field-edit/register-field-edit.component';

import { RegisterContainerCreateComponent } from './register-container-create/register-container-create.component';
import { RegisterContainerEditComponent } from './register-container-edit/register-container-edit.component';

import { RegisterPrintModule } from './register-print/register-print.module';
import { RegisterRoutingModule } from './register.routing.module';

import { RegisterService } from './register.service';
import { RegisterServiceFields } from './register.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        RegisterRoutingModule,
        RegisterPrintModule,

    ],
    declarations: [
        RegisterComponent,
        RegisterContainerFilterComponent,
        RegisterFieldFilterComponent,
        RegisterEditComponent,
        RegisterCreateComponent,
        RegisterDetailsComponent,
        RegisterFieldCreateComponent,
        RegisterFieldEditComponent,
        RegisterContainerCreateComponent,
        RegisterContainerEditComponent
    ],
    providers: [RegisterService,RegisterServiceFields, ApiService],
	exports: [RegisterComponent, RegisterEditComponent, RegisterCreateComponent]
})
export class RegisterModule {


}
