import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { RegisterComponent } from './register.component';
import { RegisterEditComponent } from './register-edit/register-edit.component';
import { RegisterDetailsComponent } from './register-details/register-details.component';
import { RegisterCreateComponent } from './register-create/register-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "Register" }, component: RegisterComponent },
            { path: 'edit/:id', data : { title : "Register" } ,component: RegisterEditComponent },
            { path: 'details/:id', data : { title : "Register" }, component: RegisterDetailsComponent },
            { path: 'create', data : { title : "Register" }, component: RegisterCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class RegisterRoutingModule {
}