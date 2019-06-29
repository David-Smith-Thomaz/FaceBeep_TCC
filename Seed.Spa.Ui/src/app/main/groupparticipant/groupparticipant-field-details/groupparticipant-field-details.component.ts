
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-groupparticipant-field-details',
    templateUrl: './groupparticipant-field-details.component.html',
    styleUrls: ['./groupparticipant-field-details.component.css']
})
export class GroupParticipantFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
