import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statususer-field-filter',
    templateUrl: './statususer-field-filter.component.html',
    styleUrls: ['./statususer-field-filter.component.css']
})
export class StatusUserFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
