import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';
import { CommonSharedModule } from '../common/common-shared.module';
import { CadastroAlunoComponent } from './cadastroAluno.component';
import { ApiService } from '../common/services/api.service';
import { CadastroAlunoService } from './cadastroAluno.service';
import { CadastroAlunoServiceFields } from './cadastroAluno.service.fields';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        CadastroAlunoRoutingModule,

    ],
    declarations: [
        CadastroAlunoComponent,
  ],
  providers: [CadastroAlunoService, CadastroAlunoServiceFields, ApiService],
})
export class CadastroAlunoRoutingModule {


}
