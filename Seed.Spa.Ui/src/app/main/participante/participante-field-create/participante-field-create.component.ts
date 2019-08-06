import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { ParticipanteService } from '../participante.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-participante-field-create',
    templateUrl: './participante-field-create.component.html',
    styleUrls: ['./participante-field-create.component.css']
})
export class ParticipanteFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
