import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusUserService } from '../statususer.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-statususer-field-edit',
    templateUrl: './statususer-field-edit.component.html',
    styleUrls: ['./statususer-field-edit.component.css']
})
export class StatusUserFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
