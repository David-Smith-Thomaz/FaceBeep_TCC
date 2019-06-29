import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusregister-field-filter',
    templateUrl: './statusregister-field-filter.component.html',
    styleUrls: ['./statusregister-field-filter.component.css']
})
export class StatusRegisterFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
