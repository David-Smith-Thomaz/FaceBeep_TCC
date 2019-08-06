import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TurmaParticipanteService } from '../turmaparticipante.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-turmaparticipante-field-edit',
    templateUrl: './turmaparticipante-field-edit.component.html',
    styleUrls: ['./turmaparticipante-field-edit.component.css']
})
export class TurmaParticipanteFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private turmaParticipanteService: TurmaParticipanteService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
