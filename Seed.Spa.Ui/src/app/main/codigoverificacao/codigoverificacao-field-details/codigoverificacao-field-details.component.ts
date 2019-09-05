
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-codigoverificacao-field-details',
    templateUrl: './codigoverificacao-field-details.component.html',
    styleUrls: ['./codigoverificacao-field-details.component.css']
})
export class CodigoVerificacaoFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
