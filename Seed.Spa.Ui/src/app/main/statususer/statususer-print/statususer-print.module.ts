import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StatusUserPrintComponent } from './statususer-print.component';
import { StatusUserPrintRoutingModule } from './statususer-print.routing.module';

import { StatusUserService } from '../statususer.service';
import { ApiService } from '../../../common/services/api.service';
import { StatusUserServiceFields } from '../statususer.service.fields';

import { StatusUserContainerDetailsComponent } from '../statususer-container-details/statususer-container-details.component';
import { StatusUserFieldDetailsComponent } from '../statususer-field-details/statususer-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        StatusUserPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        StatusUserPrintComponent,
        StatusUserContainerDetailsComponent,
        StatusUserFieldDetailsComponent
    ],
    providers: [StatusUserService, ApiService, StatusUserServiceFields],
    exports: [StatusUserContainerDetailsComponent,StatusUserFieldDetailsComponent]
})
export class StatusUserPrintModule {

}
