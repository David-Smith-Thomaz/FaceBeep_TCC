import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { ParticipantService } from '../participant.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-participant-field-edit',
    templateUrl: './participant-field-edit.component.html',
    styleUrls: ['./participant-field-edit.component.css']
})
export class ParticipantFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
