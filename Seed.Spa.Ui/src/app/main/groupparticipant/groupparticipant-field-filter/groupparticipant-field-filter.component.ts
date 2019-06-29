import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-groupparticipant-field-filter',
    templateUrl: './groupparticipant-field-filter.component.html',
    styleUrls: ['./groupparticipant-field-filter.component.css']
})
export class GroupParticipantFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
