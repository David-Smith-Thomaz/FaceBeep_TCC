import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { RegisterService } from '../register.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-register-field-create',
    templateUrl: './register-field-create.component.html',
    styleUrls: ['./register-field-create.component.css']
})
export class RegisterFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private registerService: RegisterService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
