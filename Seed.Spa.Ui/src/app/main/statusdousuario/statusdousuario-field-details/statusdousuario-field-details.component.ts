
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusdousuario-field-details',
    templateUrl: './statusdousuario-field-details.component.html',
    styleUrls: ['./statusdousuario-field-details.component.css']
})
export class StatusDoUsuarioFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
