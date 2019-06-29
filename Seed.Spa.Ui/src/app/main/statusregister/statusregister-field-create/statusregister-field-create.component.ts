import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusRegisterService } from '../statusregister.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-statusregister-field-create',
    templateUrl: './statusregister-field-create.component.html',
    styleUrls: ['./statusregister-field-create.component.css']
})
export class StatusRegisterFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
