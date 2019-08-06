import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-usuario-field-filter',
    templateUrl: './usuario-field-filter.component.html',
    styleUrls: ['./usuario-field-filter.component.css']
})
export class UsuarioFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
