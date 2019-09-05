//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { CodigoVerificacaoService } from '../codigoverificacao.service';

@Component({
    selector: 'app-codigoverificacao-container-edit',
    templateUrl: './codigoverificacao-container-edit.component.html',
    styleUrls: ['./codigoverificacao-container-edit.component.css'],
})
export class CodigoVerificacaoContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.codigoVerificacaoService.initVM();
    }

    ngOnInit() {

       
    }

}
