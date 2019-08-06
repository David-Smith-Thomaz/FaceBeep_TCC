
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-tipodeusuario-field-details',
    templateUrl: './tipodeusuario-field-details.component.html',
    styleUrls: ['./tipodeusuario-field-details.component.css']
})
export class TipoDeUsuarioFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
