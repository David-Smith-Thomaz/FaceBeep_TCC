import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TypeUserService } from '../typeuser.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-typeuser-field-create',
    templateUrl: './typeuser-field-create.component.html',
    styleUrls: ['./typeuser-field-create.component.css']
})
export class TypeUserFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private typeUserService: TypeUserService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
