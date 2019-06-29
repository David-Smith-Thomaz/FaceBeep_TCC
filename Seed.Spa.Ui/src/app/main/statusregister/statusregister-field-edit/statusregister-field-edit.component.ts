import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusRegisterService } from '../statusregister.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-statusregister-field-edit',
    templateUrl: './statusregister-field-edit.component.html',
    styleUrls: ['./statusregister-field-edit.component.css']
})
export class StatusRegisterFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private statusRegisterService: StatusRegisterService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
