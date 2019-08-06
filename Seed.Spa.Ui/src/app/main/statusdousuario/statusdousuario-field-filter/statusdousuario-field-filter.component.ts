import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusdousuario-field-filter',
    templateUrl: './statusdousuario-field-filter.component.html',
    styleUrls: ['./statusdousuario-field-filter.component.css']
})
export class StatusDoUsuarioFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
