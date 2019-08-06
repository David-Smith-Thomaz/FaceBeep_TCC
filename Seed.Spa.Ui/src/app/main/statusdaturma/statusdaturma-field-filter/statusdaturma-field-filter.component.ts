import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusdaturma-field-filter',
    templateUrl: './statusdaturma-field-filter.component.html',
    styleUrls: ['./statusdaturma-field-filter.component.css']
})
export class StatusDaTurmaFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
