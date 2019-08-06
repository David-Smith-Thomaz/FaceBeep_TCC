
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-turmaparticipante-field-details',
    templateUrl: './turmaparticipante-field-details.component.html',
    styleUrls: ['./turmaparticipante-field-details.component.css']
})
export class TurmaParticipanteFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
