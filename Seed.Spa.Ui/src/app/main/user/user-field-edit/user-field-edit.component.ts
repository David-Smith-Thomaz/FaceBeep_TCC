import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { UserService } from '../user.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-user-field-edit',
    templateUrl: './user-field-edit.component.html',
    styleUrls: ['./user-field-edit.component.css']
})
export class UserFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
