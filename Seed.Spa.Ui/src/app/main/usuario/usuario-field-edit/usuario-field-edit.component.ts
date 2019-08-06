import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { UsuarioService } from '../usuario.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-usuario-field-edit',
    templateUrl: './usuario-field-edit.component.html',
    styleUrls: ['./usuario-field-edit.component.css']
})
export class UsuarioFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private usuarioService: UsuarioService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
