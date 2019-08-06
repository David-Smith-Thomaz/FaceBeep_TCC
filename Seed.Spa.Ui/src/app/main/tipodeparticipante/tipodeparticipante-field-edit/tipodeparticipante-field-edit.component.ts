import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TipoDeParticipanteService } from '../tipodeparticipante.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-tipodeparticipante-field-edit',
    templateUrl: './tipodeparticipante-field-edit.component.html',
    styleUrls: ['./tipodeparticipante-field-edit.component.css']
})
export class TipoDeParticipanteFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
