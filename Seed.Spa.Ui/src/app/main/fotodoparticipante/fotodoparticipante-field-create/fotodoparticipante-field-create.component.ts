import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { FotoDoParticipanteService } from '../fotodoparticipante.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-fotodoparticipante-field-create',
    templateUrl: './fotodoparticipante-field-create.component.html',
    styleUrls: ['./fotodoparticipante-field-create.component.css']
})
export class FotoDoParticipanteFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
