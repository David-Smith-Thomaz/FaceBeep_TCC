import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-turmaparticipante-field-filter',
    templateUrl: './turmaparticipante-field-filter.component.html',
    styleUrls: ['./turmaparticipante-field-filter.component.css']
})
export class TurmaParticipanteFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
