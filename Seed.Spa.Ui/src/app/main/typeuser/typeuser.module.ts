import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { TypeUserComponent } from './typeuser.component';

import { TypeUserContainerFilterComponent } from './typeuser-container-filter/typeuser-container-filter.component';
import { TypeUserFieldFilterComponent } from './typeuser-field-filter/typeuser-field-filter.component';

import { TypeUserEditComponent } from './typeuser-edit/typeuser-edit.component';
import { TypeUserCreateComponent } from './typeuser-create/typeuser-create.component';
import { TypeUserDetailsComponent } from './typeuser-details/typeuser-details.component';

import { TypeUserFieldCreateComponent } from './typeuser-field-create/typeuser-field-create.component';
import { TypeUserFieldEditComponent } from './typeuser-field-edit/typeuser-field-edit.component';

import { TypeUserContainerCreateComponent } from './typeuser-container-create/typeuser-container-create.component';
import { TypeUserContainerEditComponent } from './typeuser-container-edit/typeuser-container-edit.component';

import { TypeUserPrintModule } from './typeuser-print/typeuser-print.module';
import { TypeUserRoutingModule } from './typeuser.routing.module';

import { TypeUserService } from './typeuser.service';
import { TypeUserServiceFields } from './typeuser.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        TypeUserRoutingModule,
        TypeUserPrintModule,

    ],
    declarations: [
        TypeUserComponent,
        TypeUserContainerFilterComponent,
        TypeUserFieldFilterComponent,
        TypeUserEditComponent,
        TypeUserCreateComponent,
        TypeUserDetailsComponent,
        TypeUserFieldCreateComponent,
        TypeUserFieldEditComponent,
        TypeUserContainerCreateComponent,
        TypeUserContainerEditComponent
    ],
    providers: [TypeUserService,TypeUserServiceFields, ApiService],
	exports: [TypeUserComponent, TypeUserEditComponent, TypeUserCreateComponent]
})
export class TypeUserModule {


}
