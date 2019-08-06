import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-participante-field-filter',
    templateUrl: './participante-field-filter.component.html',
    styleUrls: ['./participante-field-filter.component.css']
})
export class ParticipanteFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
