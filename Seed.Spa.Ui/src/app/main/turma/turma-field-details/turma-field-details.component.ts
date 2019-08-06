
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-turma-field-details',
    templateUrl: './turma-field-details.component.html',
    styleUrls: ['./turma-field-details.component.css']
})
export class TurmaFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
