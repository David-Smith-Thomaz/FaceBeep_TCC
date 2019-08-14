import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';
import { DashBoardRoutingModule } from './dashboard.routing.module';
import { DashBoardService } from './dashboard.service';
import { DashBoardComponent } from './dashboard.component';
import { DashBoardServiceFields } from './dashboard.service.fields';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        DashBoardRoutingModule,

    ],
    declarations: [
        DashBoardComponent,
  ],
  providers: [DashBoardService, DashBoardServiceFields, ApiService],
})
export class DashBoardModule {


}
