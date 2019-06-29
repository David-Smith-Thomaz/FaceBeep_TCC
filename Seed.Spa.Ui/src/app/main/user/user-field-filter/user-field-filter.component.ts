import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-user-field-filter',
    templateUrl: './user-field-filter.component.html',
    styleUrls: ['./user-field-filter.component.css']
})
export class UserFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
