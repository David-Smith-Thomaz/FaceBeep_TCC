import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { UsuarioService } from '../usuario.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-usuario-field-create',
    templateUrl: './usuario-field-create.component.html',
    styleUrls: ['./usuario-field-create.component.css']
})
export class UsuarioFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
