
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-tipodeparticipante-field-details',
    templateUrl: './tipodeparticipante-field-details.component.html',
    styleUrls: ['./tipodeparticipante-field-details.component.css']
})
export class TipoDeParticipanteFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
