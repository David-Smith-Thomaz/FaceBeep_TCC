
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-fotodoparticipante-field-details',
    templateUrl: './fotodoparticipante-field-details.component.html',
    styleUrls: ['./fotodoparticipante-field-details.component.css']
})
export class FotoDoParticipanteFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
