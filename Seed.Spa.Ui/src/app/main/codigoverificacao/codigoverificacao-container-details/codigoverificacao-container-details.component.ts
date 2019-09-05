//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { CodigoVerificacaoService } from '../codigoverificacao.service';

@Component({
    selector: 'app-codigoverificacao-container-details',
    templateUrl: './codigoverificacao-container-details.component.html',
    styleUrls: ['./codigoverificacao-container-details.component.css'],
})
export class CodigoVerificacaoContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.codigoVerificacaoService.initVM();
    }

    ngOnInit() {

       
    }

}
