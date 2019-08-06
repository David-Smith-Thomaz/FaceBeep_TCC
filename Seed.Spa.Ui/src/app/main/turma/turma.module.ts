import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { TurmaComponent } from './turma.component';

import { TurmaContainerFilterComponent } from './turma-container-filter/turma-container-filter.component';
import { TurmaFieldFilterComponent } from './turma-field-filter/turma-field-filter.component';

import { TurmaEditComponent } from './turma-edit/turma-edit.component';
import { TurmaCreateComponent } from './turma-create/turma-create.component';
import { TurmaDetailsComponent } from './turma-details/turma-details.component';

import { TurmaFieldCreateComponent } from './turma-field-create/turma-field-create.component';
import { TurmaFieldEditComponent } from './turma-field-edit/turma-field-edit.component';

import { TurmaContainerCreateComponent } from './turma-container-create/turma-container-create.component';
import { TurmaContainerEditComponent } from './turma-container-edit/turma-container-edit.component';

import { TurmaPrintModule } from './turma-print/turma-print.module';
import { TurmaRoutingModule } from './turma.routing.module';

import { TurmaService } from './turma.service';
import { TurmaServiceFields } from './turma.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        TurmaRoutingModule,
        TurmaPrintModule,

    ],
    declarations: [
        TurmaComponent,
        TurmaContainerFilterComponent,
        TurmaFieldFilterComponent,
        TurmaEditComponent,
        TurmaCreateComponent,
        TurmaDetailsComponent,
        TurmaFieldCreateComponent,
        TurmaFieldEditComponent,
        TurmaContainerCreateComponent,
        TurmaContainerEditComponent
    ],
    providers: [TurmaService,TurmaServiceFields, ApiService],
	exports: [TurmaComponent, TurmaEditComponent, TurmaCreateComponent]
})
export class TurmaModule {


}
