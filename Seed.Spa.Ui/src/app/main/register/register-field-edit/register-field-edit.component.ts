import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { RegisterService } from '../register.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-register-field-edit',
    templateUrl: './register-field-edit.component.html',
    styleUrls: ['./register-field-edit.component.css']
})
export class RegisterFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
