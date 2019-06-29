import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { GroupParticipantService } from '../groupparticipant.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-groupparticipant-field-create',
    templateUrl: './groupparticipant-field-create.component.html',
    styleUrls: ['./groupparticipant-field-create.component.css']
})
export class GroupParticipantFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
