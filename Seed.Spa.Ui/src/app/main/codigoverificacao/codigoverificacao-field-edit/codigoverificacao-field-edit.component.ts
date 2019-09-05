import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { CodigoVerificacaoService } from '../codigoverificacao.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-codigoverificacao-field-edit',
    templateUrl: './codigoverificacao-field-edit.component.html',
    styleUrls: ['./codigoverificacao-field-edit.component.css']
})
export class CodigoVerificacaoFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
