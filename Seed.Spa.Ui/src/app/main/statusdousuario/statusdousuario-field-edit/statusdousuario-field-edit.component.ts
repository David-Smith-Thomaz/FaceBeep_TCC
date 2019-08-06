import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusDoUsuarioService } from '../statusdousuario.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-statusdousuario-field-edit',
    templateUrl: './statusdousuario-field-edit.component.html',
    styleUrls: ['./statusdousuario-field-edit.component.css']
})
export class StatusDoUsuarioFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private statusDoUsuarioService: StatusDoUsuarioService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
