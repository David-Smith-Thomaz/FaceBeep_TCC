import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-turma-field-filter',
    templateUrl: './turma-field-filter.component.html',
    styleUrls: ['./turma-field-filter.component.css']
})
export class TurmaFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
