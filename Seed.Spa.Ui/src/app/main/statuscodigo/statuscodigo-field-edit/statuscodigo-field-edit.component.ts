import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusCodigoService } from '../statuscodigo.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-statuscodigo-field-edit',
    templateUrl: './statuscodigo-field-edit.component.html',
    styleUrls: ['./statuscodigo-field-edit.component.css']
})
export class StatusCodigoFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private statusCodigoService: StatusCodigoService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
