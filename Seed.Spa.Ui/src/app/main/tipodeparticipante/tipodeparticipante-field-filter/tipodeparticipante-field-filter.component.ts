import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-tipodeparticipante-field-filter',
    templateUrl: './tipodeparticipante-field-filter.component.html',
    styleUrls: ['./tipodeparticipante-field-filter.component.css']
})
export class TipoDeParticipanteFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
