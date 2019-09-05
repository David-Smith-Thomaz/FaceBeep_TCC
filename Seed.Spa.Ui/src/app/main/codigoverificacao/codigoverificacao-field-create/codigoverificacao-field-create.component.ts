import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { CodigoVerificacaoService } from '../codigoverificacao.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-codigoverificacao-field-create',
    templateUrl: './codigoverificacao-field-create.component.html',
    styleUrls: ['./codigoverificacao-field-create.component.css']
})
export class CodigoVerificacaoFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
