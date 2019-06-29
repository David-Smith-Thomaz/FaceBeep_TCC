
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-participant-field-details',
    templateUrl: './participant-field-details.component.html',
    styleUrls: ['./participant-field-details.component.css']
})
export class ParticipantFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
