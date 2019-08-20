import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-fotodoparticipante-field-filter',
    templateUrl: './fotodoparticipante-field-filter.component.html',
    styleUrls: ['./fotodoparticipante-field-filter.component.css']
})
export class FotoDoParticipanteFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
