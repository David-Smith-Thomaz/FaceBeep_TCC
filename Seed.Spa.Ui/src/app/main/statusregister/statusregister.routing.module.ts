import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StatusRegisterComponent } from './statusregister.component';
import { StatusRegisterEditComponent } from './statusregister-edit/statusregister-edit.component';
import { StatusRegisterDetailsComponent } from './statusregister-details/statusregister-details.component';
import { StatusRegisterCreateComponent } from './statusregister-create/statusregister-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "StatusRegister" }, component: StatusRegisterComponent },
            { path: 'edit/:id', data : { title : "StatusRegister" } ,component: StatusRegisterEditComponent },
            { path: 'details/:id', data : { title : "StatusRegister" }, component: StatusRegisterDetailsComponent },
            { path: 'create', data : { title : "StatusRegister" }, component: StatusRegisterCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class StatusRegisterRoutingModule {
}