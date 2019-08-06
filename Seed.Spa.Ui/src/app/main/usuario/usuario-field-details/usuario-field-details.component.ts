
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-usuario-field-details',
    templateUrl: './usuario-field-details.component.html',
    styleUrls: ['./usuario-field-details.component.css']
})
export class UsuarioFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
