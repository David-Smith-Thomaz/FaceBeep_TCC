import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { ParticipanteService } from '../participante.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-participante-field-edit',
    templateUrl: './participante-field-edit.component.html',
    styleUrls: ['./participante-field-edit.component.css']
})
export class ParticipanteFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private participanteService: ParticipanteService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
