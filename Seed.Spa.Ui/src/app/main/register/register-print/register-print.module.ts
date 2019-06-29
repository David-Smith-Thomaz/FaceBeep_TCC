import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RegisterPrintComponent } from './register-print.component';
import { RegisterPrintRoutingModule } from './register-print.routing.module';

import { RegisterService } from '../register.service';
import { ApiService } from '../../../common/services/api.service';
import { RegisterServiceFields } from '../register.service.fields';

import { RegisterContainerDetailsComponent } from '../register-container-details/register-container-details.component';
import { RegisterFieldDetailsComponent } from '../register-field-details/register-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        RegisterPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        RegisterPrintComponent,
        RegisterContainerDetailsComponent,
        RegisterFieldDetailsComponent
    ],
    providers: [RegisterService, ApiService, RegisterServiceFields],
    exports: [RegisterContainerDetailsComponent,RegisterFieldDetailsComponent]
})
export class RegisterPrintModule {

}
