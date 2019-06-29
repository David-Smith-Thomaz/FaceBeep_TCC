import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusUserComponent } from './statususer.component';
import { StatusUserEditComponent } from './statususer-edit/statususer-edit.component';
import { StatusUserDetailsComponent } from './statususer-details/statususer-details.component';
import { StatusUserCreateComponent } from './statususer-create/statususer-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "StatusUser" }, component: StatusUserComponent },
            { path: 'edit/:id', data : { title : "StatusUser" } ,component: StatusUserEditComponent },
            { path: 'details/:id', data : { title : "StatusUser" }, component: StatusUserDetailsComponent },
            { path: 'create', data : { title : "StatusUser" }, component: StatusUserCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class StatusUserRoutingModule {
}