import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusDoUsuarioService } from '../statusdousuario.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-statusdousuario-field-create',
    templateUrl: './statusdousuario-field-create.component.html',
    styleUrls: ['./statusdousuario-field-create.component.css']
})
export class StatusDoUsuarioFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
