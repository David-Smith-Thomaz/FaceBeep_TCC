import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { UserPrintComponent } from './user-print.component';
import { UserPrintRoutingModule } from './user-print.routing.module';

import { UserService } from '../user.service';
import { ApiService } from '../../../common/services/api.service';
import { UserServiceFields } from '../user.service.fields';

import { UserContainerDetailsComponent } from '../user-container-details/user-container-details.component';
import { UserFieldDetailsComponent } from '../user-field-details/user-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        UserPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        UserPrintComponent,
        UserContainerDetailsComponent,
        UserFieldDetailsComponent
    ],
    providers: [UserService, ApiService, UserServiceFields],
    exports: [UserContainerDetailsComponent,UserFieldDetailsComponent]
})
export class UserPrintModule {

}
