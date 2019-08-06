import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TurmaPrintComponent } from './turma-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: TurmaPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  TurmaPrintRoutingModule {

}