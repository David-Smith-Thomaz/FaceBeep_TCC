import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { StatusDaTurmaComponent } from './statusdaturma.component';

import { StatusDaTurmaContainerFilterComponent } from './statusdaturma-container-filter/statusdaturma-container-filter.component';
import { StatusDaTurmaFieldFilterComponent } from './statusdaturma-field-filter/statusdaturma-field-filter.component';

import { StatusDaTurmaEditComponent } from './statusdaturma-edit/statusdaturma-edit.component';
import { StatusDaTurmaCreateComponent } from './statusdaturma-create/statusdaturma-create.component';
import { StatusDaTurmaDetailsComponent } from './statusdaturma-details/statusdaturma-details.component';

import { StatusDaTurmaFieldCreateComponent } from './statusdaturma-field-create/statusdaturma-field-create.component';
import { StatusDaTurmaFieldEditComponent } from './statusdaturma-field-edit/statusdaturma-field-edit.component';

import { StatusDaTurmaContainerCreateComponent } from './statusdaturma-container-create/statusdaturma-container-create.component';
import { StatusDaTurmaContainerEditComponent } from './statusdaturma-container-edit/statusdaturma-container-edit.component';

import { StatusDaTurmaPrintModule } from './statusdaturma-print/statusdaturma-print.module';
import { StatusDaTurmaRoutingModule } from './statusdaturma.routing.module';

import { StatusDaTurmaService } from './statusdaturma.service';
import { StatusDaTurmaServiceFields } from './statusdaturma.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        StatusDaTurmaRoutingModule,
        StatusDaTurmaPrintModule,

    ],
    declarations: [
        StatusDaTurmaComponent,
        StatusDaTurmaContainerFilterComponent,
        StatusDaTurmaFieldFilterComponent,
        StatusDaTurmaEditComponent,
        StatusDaTurmaCreateComponent,
        StatusDaTurmaDetailsComponent,
        StatusDaTurmaFieldCreateComponent,
        StatusDaTurmaFieldEditComponent,
        StatusDaTurmaContainerCreateComponent,
        StatusDaTurmaContainerEditComponent
    ],
    providers: [StatusDaTurmaService,StatusDaTurmaServiceFields, ApiService],
	exports: [StatusDaTurmaComponent, StatusDaTurmaEditComponent, StatusDaTurmaCreateComponent]
})
export class StatusDaTurmaModule {


}
