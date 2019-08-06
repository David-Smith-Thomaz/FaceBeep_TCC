import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TipoDeParticipanteService } from '../tipodeparticipante.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-tipodeparticipante-field-create',
    templateUrl: './tipodeparticipante-field-create.component.html',
    styleUrls: ['./tipodeparticipante-field-create.component.css']
})
export class TipoDeParticipanteFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private tipoDeParticipanteService: TipoDeParticipanteService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
