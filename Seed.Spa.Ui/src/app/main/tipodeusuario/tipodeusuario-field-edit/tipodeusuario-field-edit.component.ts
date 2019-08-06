import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TipoDeUsuarioService } from '../tipodeusuario.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-tipodeusuario-field-edit',
    templateUrl: './tipodeusuario-field-edit.component.html',
    styleUrls: ['./tipodeusuario-field-edit.component.css']
})
export class TipoDeUsuarioFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private tipoDeUsuarioService: TipoDeUsuarioService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
