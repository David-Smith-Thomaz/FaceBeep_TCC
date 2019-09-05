import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-codigoverificacao-field-filter',
    templateUrl: './codigoverificacao-field-filter.component.html',
    styleUrls: ['./codigoverificacao-field-filter.component.css']
})
export class CodigoVerificacaoFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
