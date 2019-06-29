import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { ParticipantService } from '../participant.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-participant-field-create',
    templateUrl: './participant-field-create.component.html',
    styleUrls: ['./participant-field-create.component.css']
})
export class ParticipantFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private participantService: ParticipantService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
