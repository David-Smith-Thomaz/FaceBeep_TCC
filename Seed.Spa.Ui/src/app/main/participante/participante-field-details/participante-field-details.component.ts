
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-participante-field-details',
    templateUrl: './participante-field-details.component.html',
    styleUrls: ['./participante-field-details.component.css']
})
export class ParticipanteFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
