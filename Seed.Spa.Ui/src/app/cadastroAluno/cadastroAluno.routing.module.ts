import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CadastroAlunoComponent } from './cadastroAluno.component';

@NgModule({
    imports: [
        RouterModule.forChild([
        { path: '', data: { title: "CadastroAluno" }, component: CadastroAlunoComponent },
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class DashBoardRoutingModule {
}
