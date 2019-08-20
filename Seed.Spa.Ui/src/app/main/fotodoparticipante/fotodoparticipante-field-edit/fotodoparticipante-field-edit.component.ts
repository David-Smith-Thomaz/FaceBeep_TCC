import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { FotoDoParticipanteService } from '../fotodoparticipante.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-fotodoparticipante-field-edit',
    templateUrl: './fotodoparticipante-field-edit.component.html',
    styleUrls: ['./fotodoparticipante-field-edit.component.css']
})
export class FotoDoParticipanteFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private fotoDoParticipanteService: FotoDoParticipanteService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
