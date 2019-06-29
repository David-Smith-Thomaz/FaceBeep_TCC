import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-typeuser-field-filter',
    templateUrl: './typeuser-field-filter.component.html',
    styleUrls: ['./typeuser-field-filter.component.css']
})
export class TypeUserFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
