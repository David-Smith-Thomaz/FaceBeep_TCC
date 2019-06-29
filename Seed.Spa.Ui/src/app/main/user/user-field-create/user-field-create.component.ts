import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { UserService } from '../user.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-user-field-create',
    templateUrl: './user-field-create.component.html',
    styleUrls: ['./user-field-create.component.css']
})
export class UserFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private userService: UserService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
