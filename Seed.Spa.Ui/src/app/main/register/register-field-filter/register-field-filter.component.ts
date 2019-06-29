import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-register-field-filter',
    templateUrl: './register-field-filter.component.html',
    styleUrls: ['./register-field-filter.component.css']
})
export class RegisterFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
