import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { GroupParticipantService } from '../groupparticipant.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-groupparticipant-field-edit',
    templateUrl: './groupparticipant-field-edit.component.html',
    styleUrls: ['./groupparticipant-field-edit.component.css']
})
export class GroupParticipantFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private groupParticipantService: GroupParticipantService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
