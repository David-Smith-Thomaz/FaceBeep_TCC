import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StatusRegisterPrintComponent } from './statusregister-print.component';
import { StatusRegisterPrintRoutingModule } from './statusregister-print.routing.module';

import { StatusRegisterService } from '../statusregister.service';
import { ApiService } from '../../../common/services/api.service';
import { StatusRegisterServiceFields } from '../statusregister.service.fields';

import { StatusRegisterContainerDetailsComponent } from '../statusregister-container-details/statusregister-container-details.component';
import { StatusRegisterFieldDetailsComponent } from '../statusregister-field-details/statusregister-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        StatusRegisterPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        StatusRegisterPrintComponent,
        StatusRegisterContainerDetailsComponent,
        StatusRegisterFieldDetailsComponent
    ],
    providers: [StatusRegisterService, ApiService, StatusRegisterServiceFields],
    exports: [StatusRegisterContainerDetailsComponent,StatusRegisterFieldDetailsComponent]
})
export class StatusRegisterPrintModule {

}
