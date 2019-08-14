import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { GlobalService } from '../../global.service';
import { DashBoardComponent } from './dashboard.component';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "DashBoard" }, component: DashBoardComponent },
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class DashBoardRoutingModule {
}
