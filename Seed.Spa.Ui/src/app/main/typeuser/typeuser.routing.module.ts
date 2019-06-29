import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TypeUserComponent } from './typeuser.component';
import { TypeUserEditComponent } from './typeuser-edit/typeuser-edit.component';
import { TypeUserDetailsComponent } from './typeuser-details/typeuser-details.component';
import { TypeUserCreateComponent } from './typeuser-create/typeuser-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "TypeUser" }, component: TypeUserComponent },
            { path: 'edit/:id', data : { title : "TypeUser" } ,component: TypeUserEditComponent },
            { path: 'details/:id', data : { title : "TypeUser" }, component: TypeUserDetailsComponent },
            { path: 'create', data : { title : "TypeUser" }, component: TypeUserCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class TypeUserRoutingModule {
}