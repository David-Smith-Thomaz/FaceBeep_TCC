import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TurmaPrintComponent } from './turma-print.component';
import { TurmaPrintRoutingModule } from './turma-print.routing.module';

import { TurmaService } from '../turma.service';
import { ApiService } from '../../../common/services/api.service';
import { TurmaServiceFields } from '../turma.service.fields';

import { TurmaContainerDetailsComponent } from '../turma-container-details/turma-container-details.component';
import { TurmaFieldDetailsComponent } from '../turma-field-details/turma-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        TurmaPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        TurmaPrintComponent,
        TurmaContainerDetailsComponent,
        TurmaFieldDetailsComponent
    ],
    providers: [TurmaService, ApiService, TurmaServiceFields],
    exports: [TurmaContainerDetailsComponent,TurmaFieldDetailsComponent]
})
export class TurmaPrintModule {

}
