import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TypeUserPrintComponent } from './typeuser-print.component';
import { TypeUserPrintRoutingModule } from './typeuser-print.routing.module';

import { TypeUserService } from '../typeuser.service';
import { ApiService } from '../../../common/services/api.service';
import { TypeUserServiceFields } from '../typeuser.service.fields';

import { TypeUserContainerDetailsComponent } from '../typeuser-container-details/typeuser-container-details.component';
import { TypeUserFieldDetailsComponent } from '../typeuser-field-details/typeuser-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        TypeUserPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        TypeUserPrintComponent,
        TypeUserContainerDetailsComponent,
        TypeUserFieldDetailsComponent
    ],
    providers: [TypeUserService, ApiService, TypeUserServiceFields],
    exports: [TypeUserContainerDetailsComponent,TypeUserFieldDetailsComponent]
})
export class TypeUserPrintModule {

}
