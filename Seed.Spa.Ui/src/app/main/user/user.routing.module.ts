import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UserComponent } from './user.component';
import { UserEditComponent } from './user-edit/user-edit.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UserCreateComponent } from './user-create/user-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "User" }, component: UserComponent },
            { path: 'edit/:id', data : { title : "User" } ,component: UserEditComponent },
            { path: 'details/:id', data : { title : "User" }, component: UserDetailsComponent },
            { path: 'create', data : { title : "User" }, component: UserCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class UserRoutingModule {
}