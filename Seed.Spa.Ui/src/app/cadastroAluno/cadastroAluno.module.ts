import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';
import { CommonSharedModule } from '../common/common-shared.module';
import { CadastroAlunoComponent } from './cadastroAluno.component';
import { ApiService } from '../common/services/api.service';
import { CadastroAlunoService } from './cadastroAluno.service';
import { UtilSharedModule } from '../util/util-shared.module';
import { WebcamModule } from 'ngx-webcam';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        CadastroAlunoRoutingModule,
        UtilSharedModule,
        WebcamModule,
        BrowserModule,
        FormsModule,
    ],
    declarations: [
        CadastroAlunoComponent,
  ],
  providers: [CadastroAlunoService, ApiService],
  exports: [CadastroAlunoComponent]
})
export class CadastroAlunoRoutingModule {


}
