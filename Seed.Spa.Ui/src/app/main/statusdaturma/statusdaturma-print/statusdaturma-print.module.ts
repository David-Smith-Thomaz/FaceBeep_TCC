import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StatusDaTurmaPrintComponent } from './statusdaturma-print.component';
import { StatusDaTurmaPrintRoutingModule } from './statusdaturma-print.routing.module';

import { StatusDaTurmaService } from '../statusdaturma.service';
import { ApiService } from '../../../common/services/api.service';
import { StatusDaTurmaServiceFields } from '../statusdaturma.service.fields';

import { StatusDaTurmaContainerDetailsComponent } from '../statusdaturma-container-details/statusdaturma-container-details.component';
import { StatusDaTurmaFieldDetailsComponent } from '../statusdaturma-field-details/statusdaturma-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        StatusDaTurmaPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        StatusDaTurmaPrintComponent,
        StatusDaTurmaContainerDetailsComponent,
        StatusDaTurmaFieldDetailsComponent
    ],
    providers: [StatusDaTurmaService, ApiService, StatusDaTurmaServiceFields],
    exports: [StatusDaTurmaContainerDetailsComponent,StatusDaTurmaFieldDetailsComponent]
})
export class StatusDaTurmaPrintModule {

}
