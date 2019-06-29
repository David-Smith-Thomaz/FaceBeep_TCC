import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { UserComponent } from './user.component';

import { UserContainerFilterComponent } from './user-container-filter/user-container-filter.component';
import { UserFieldFilterComponent } from './user-field-filter/user-field-filter.component';

import { UserEditComponent } from './user-edit/user-edit.component';
import { UserCreateComponent } from './user-create/user-create.component';
import { UserDetailsComponent } from './user-details/user-details.component';

import { UserFieldCreateComponent } from './user-field-create/user-field-create.component';
import { UserFieldEditComponent } from './user-field-edit/user-field-edit.component';

import { UserContainerCreateComponent } from './user-container-create/user-container-create.component';
import { UserContainerEditComponent } from './user-container-edit/user-container-edit.component';

import { UserPrintModule } from './user-print/user-print.module';
import { UserRoutingModule } from './user.routing.module';

import { UserService } from './user.service';
import { UserServiceFields } from './user.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        UserRoutingModule,
        UserPrintModule,

    ],
    declarations: [
        UserComponent,
        UserContainerFilterComponent,
        UserFieldFilterComponent,
        UserEditComponent,
        UserCreateComponent,
        UserDetailsComponent,
        UserFieldCreateComponent,
        UserFieldEditComponent,
        UserContainerCreateComponent,
        UserContainerEditComponent
    ],
    providers: [UserService,UserServiceFields, ApiService],
	exports: [UserComponent, UserEditComponent, UserCreateComponent]
})
export class UserModule {


}
