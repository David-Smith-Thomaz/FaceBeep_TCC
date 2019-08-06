import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TurmaParticipanteService } from '../turmaparticipante.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-turmaparticipante-field-create',
    templateUrl: './turmaparticipante-field-create.component.html',
    styleUrls: ['./turmaparticipante-field-create.component.css']
})
export class TurmaParticipanteFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
