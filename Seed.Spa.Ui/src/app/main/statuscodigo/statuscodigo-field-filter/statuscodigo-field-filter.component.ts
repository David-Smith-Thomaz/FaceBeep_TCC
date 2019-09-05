import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statuscodigo-field-filter',
    templateUrl: './statuscodigo-field-filter.component.html',
    styleUrls: ['./statuscodigo-field-filter.component.css']
})
export class StatusCodigoFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
