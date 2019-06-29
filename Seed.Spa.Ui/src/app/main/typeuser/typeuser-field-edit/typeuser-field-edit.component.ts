import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TypeUserService } from '../typeuser.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-typeuser-field-edit',
    templateUrl: './typeuser-field-edit.component.html',
    styleUrls: ['./typeuser-field-edit.component.css']
})
export class TypeUserFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
