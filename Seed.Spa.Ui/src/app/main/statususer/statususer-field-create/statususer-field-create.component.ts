import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusUserService } from '../statususer.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-statususer-field-create',
    templateUrl: './statususer-field-create.component.html',
    styleUrls: ['./statususer-field-create.component.css']
})
export class StatusUserFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private statusUserService: StatusUserService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
