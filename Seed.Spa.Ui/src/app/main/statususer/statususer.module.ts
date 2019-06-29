import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { StatusUserComponent } from './statususer.component';

import { StatusUserContainerFilterComponent } from './statususer-container-filter/statususer-container-filter.component';
import { StatusUserFieldFilterComponent } from './statususer-field-filter/statususer-field-filter.component';

import { StatusUserEditComponent } from './statususer-edit/statususer-edit.component';
import { StatusUserCreateComponent } from './statususer-create/statususer-create.component';
import { StatusUserDetailsComponent } from './statususer-details/statususer-details.component';

import { StatusUserFieldCreateComponent } from './statususer-field-create/statususer-field-create.component';
import { StatusUserFieldEditComponent } from './statususer-field-edit/statususer-field-edit.component';

import { StatusUserContainerCreateComponent } from './statususer-container-create/statususer-container-create.component';
import { StatusUserContainerEditComponent } from './statususer-container-edit/statususer-container-edit.component';

import { StatusUserPrintModule } from './statususer-print/statususer-print.module';
import { StatusUserRoutingModule } from './statususer.routing.module';

import { StatusUserService } from './statususer.service';
import { StatusUserServiceFields } from './statususer.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        StatusUserRoutingModule,
        StatusUserPrintModule,

    ],
    declarations: [
        StatusUserComponent,
        StatusUserContainerFilterComponent,
        StatusUserFieldFilterComponent,
        StatusUserEditComponent,
        StatusUserCreateComponent,
        StatusUserDetailsComponent,
        StatusUserFieldCreateComponent,
        StatusUserFieldEditComponent,
        StatusUserContainerCreateComponent,
        StatusUserContainerEditComponent
    ],
    providers: [StatusUserService,StatusUserServiceFields, ApiService],
	exports: [StatusUserComponent, StatusUserEditComponent, StatusUserCreateComponent]
})
export class StatusUserModule {


}
