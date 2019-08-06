import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TipoDeUsuarioService } from '../tipodeusuario.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-tipodeusuario-field-create',
    templateUrl: './tipodeusuario-field-create.component.html',
    styleUrls: ['./tipodeusuario-field-create.component.css']
})
export class TipoDeUsuarioFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
