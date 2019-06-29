import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-participant-field-filter',
    templateUrl: './participant-field-filter.component.html',
    styleUrls: ['./participant-field-filter.component.css']
})
export class ParticipantFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
