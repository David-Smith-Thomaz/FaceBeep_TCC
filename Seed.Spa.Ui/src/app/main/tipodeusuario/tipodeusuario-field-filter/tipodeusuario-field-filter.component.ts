import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-tipodeusuario-field-filter',
    templateUrl: './tipodeusuario-field-filter.component.html',
    styleUrls: ['./tipodeusuario-field-filter.component.css']
})
export class TipoDeUsuarioFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
